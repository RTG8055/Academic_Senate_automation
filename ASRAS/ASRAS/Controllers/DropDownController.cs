using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASRAS.Models;
using MongoDB.Bson;

namespace ASRAS.Controllers
{
    public class DropDownController : Controller
    {
        protected InstituteRepository _repositoryIns;
        public static List<Institute> allIns = new List<Institute>();

        public DropDownController()
        {
            _repositoryIns = new InstituteRepository();
            allIns = _repositoryIns.GetInstitutes();
        }

        public static InstituteViewModal instVM = new InstituteViewModal();
        public ActionResult InstituteView()
        {
            instVM.InsList.Clear();
            foreach (Institute i in allIns)
            {
                instVM.InsList.Add(i);
            }
            return View(instVM);
        }

        public static DepartmentViewModal deptVM = new DepartmentViewModal();
        public ActionResult DepartmentView(Double? InstituteID)
        {
            deptVM.DeptList.Clear();

            if (InstituteID != null)
            {
                if (InstituteID == 123)
                {
                    return View(deptVM);
                }

                Institute inst = allIns.Find(p => p.Ins_id.Equals(InstituteID));

                foreach (Department d in inst.Departments)
                {
                    deptVM.DeptList.Add(d);
                }
            }
            else
            {
                System.Diagnostics.Debug.Write("INSTITUTEID = NULL");
            }

            return View(deptVM);
        }

        public static CourseViewModal courseVM = new CourseViewModal();
        public ActionResult CourseView(Double? InstituteID, Double? DeptID)
        {
            courseVM.CourseList.Clear();

            if (InstituteID != null && DeptID != null)
            {
                if (InstituteID == 123)
                {
                    return View(courseVM);
                }

                Institute inst = allIns.Find(p => p.Ins_id == InstituteID);
                Department dept = inst.Departments.Find(p => p.D_id == DeptID);

                foreach (Course c in dept.Courses)
                {
                    courseVM.CourseList.Add(c);
                }
            }
            return View(courseVM);
        }

        public static SemesterViewModal semVM = new SemesterViewModal();
        public ActionResult SemesterView(Double? InstituteID, Double? DeptID, Double? CourseID)
        {
            semVM.SemesterList.Clear();
            if (InstituteID != 123 && DeptID != null && CourseID != null)
            {
                Institute inst = allIns.Find(p => p.Ins_id == InstituteID);
                Department dept = inst.Departments.Find(p => p.D_id == DeptID);
                Course course = dept.Courses.Find(p => p.C_id == CourseID);

                foreach (Semester s in course.Semesters)
                {
                    semVM.SemesterList.Add(s);
                }
            }
            return View(semVM);
        }

        public static SubjectViewModal subjVM = new SubjectViewModal();
        public ActionResult SubjectView(Double? InstituteID, Double? DeptID, Double? CourseID, Double? SemesterID, Double? Sub_type)
        {
            subjVM.SubjectList.Clear();
            if (InstituteID != 123 && DeptID != null && CourseID != null && SemesterID != null && Sub_type != null)
            {
                Institute inst = allIns.Find(p => p.Ins_id == InstituteID);
                Department dept = inst.Departments.Find(p => p.D_id == DeptID);
                Course course = dept.Courses.Find(p => p.C_id == CourseID);
                Semester sem = course.Semesters.Find(p => Double.Parse(p.S_id) == SemesterID);

                if (Sub_type == 1)
                {
                    subjVM.SubjectList = sem.Core_subs;
                }
                else if (Sub_type == 2)
                {
                    subjVM.SubjectList = sem.PE_subs;
                }
                else if (Sub_type == 3)
                {
                    subjVM.SubjectList = sem.OE_subs;
                }
            }
            return View(subjVM);
        }

    }
}