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
        public FormModal formModal;

        public DropDownController()
        {
            _repositoryIns = new InstituteRepository();
            allIns = _repositoryIns.GetInstitutes();
            formModal = new FormModal();
        }

        public ActionResult InstituteView()
        {
            formModal.instituteViewModal = new InstituteViewModal();
            formModal.instituteViewModal.InsList.Clear();
            foreach (Institute i in allIns)
            {
                formModal.instituteViewModal.InsList.Add(i);
            }
            return View(formModal);
        }

        public static DepartmentViewModal deptVM = new DepartmentViewModal();
        public ActionResult DepartmentView(Double? InstituteID)
        {
            formModal.departmentViewModal = new DepartmentViewModal();
            formModal.departmentViewModal.DeptList.Clear();

            if (InstituteID != null)
            {
                if (InstituteID == 123)
                {
                    return View(formModal);
                }

                Institute inst = allIns.Find(p => p.Ins_id.Equals(InstituteID));

                foreach (Department d in inst.Departments)
                {
                    formModal.departmentViewModal.DeptList.Add(d);
                }
            }
            else
            {
                System.Diagnostics.Debug.Write("INSTITUTEID = NULL");
            }

            return View(formModal);
        }

        public static CourseViewModal courseVM = new CourseViewModal();
        public ActionResult CourseView(Double? InstituteID, Double? DeptID)
        {
            formModal.courseViewModal = new CourseViewModal();
            formModal.courseViewModal.CourseList.Clear();

            if (InstituteID != null && DeptID != null)
            {
                if (InstituteID == 123)
                {
                    return View(formModal);
                }

                Institute inst = allIns.Find(p => p.Ins_id == InstituteID);
                Department dept = inst.Departments.Find(p => p.D_id == DeptID);

                foreach (Course c in dept.Courses)
                {
                    formModal.courseViewModal.CourseList.Add(c);
                }
            }
            return View(formModal);
        }

        public static SemesterViewModal semVM = new SemesterViewModal();
        public ActionResult SemesterView(Double? InstituteID, Double? DeptID, Double? CourseID)
        {
            formModal.semesterViewModal = new SemesterViewModal();
            formModal.semesterViewModal.SemesterList.Clear();

            if (InstituteID != 123 && DeptID != null && CourseID != null)
            {
                Institute inst = allIns.Find(p => p.Ins_id == InstituteID);
                Department dept = inst.Departments.Find(p => p.D_id == DeptID);
                Course course = dept.Courses.Find(p => p.C_id == CourseID);

                foreach (Semester s in course.Semesters)
                {
                    formModal.semesterViewModal.SemesterList.Add(s);
                }
            }
            return View(formModal);
        }

        public static SubjectViewModal subjVM = new SubjectViewModal();
        public ActionResult SubjectView(Double? InstituteID, Double? DeptID, Double? CourseID, Double? SemesterID, Double? Sub_type)
        {
            formModal.subjectViewModal = new SubjectViewModal();
            formModal.subjectViewModal.SubjectList.Clear();
            if (InstituteID != 123 && DeptID != null && CourseID != null && SemesterID != null && Sub_type != null)
            {
                Institute inst = allIns.Find(p => p.Ins_id == InstituteID);
                Department dept = inst.Departments.Find(p => p.D_id == DeptID);
                Course course = dept.Courses.Find(p => p.C_id == CourseID);
                Semester sem = course.Semesters.Find(p => Double.Parse(p.S_id) == SemesterID);

                if (Sub_type == 1)
                {
                    formModal.subjectViewModal.SubjectList = sem.Core_subs;
                }
                else if (Sub_type == 2)
                {
                    formModal.subjectViewModal.SubjectList = sem.PE_subs;
                }
                else if (Sub_type == 3)
                {
                    formModal.subjectViewModal.SubjectList = sem.OE_subs;
                }
            }
            return View(formModal);
        }

    }
}