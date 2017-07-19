using ASRAS.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class ChangeInCurriculumController : Controller
    {
        protected InstituteRepository _repositoryIns;
        public static List<Institute> All_ins2 = new List<Institute>();
        /*
        {
            new Institute
            {
                Id = new ObjectId(),
                Name = "MIT",
                Departments = new List<Department>()
                {
                    new Department()
                    {
                        D_id=1,
                        Dname = "ICT",
                        Courses = new List<Course>()
                        {
                            new Course()
                            {
                                C_id=1,
                                Cname="IT",
                                Semesters = new List<Semester>()
                                {
                                    new Semester()
                                    {
                                        S_id= "1",
                                        Core_subs=new List<Subject>() {new Subject() { Sub_id=1,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} },
                                        PE_subs = new List<Subject>() {new Subject() { Sub_id=2,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} },
                                        OE_subs = new List<Subject>() {new Subject() { Sub_id=3,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} }
                                    },
                                    new Semester()
                                    {
                                        S_id= "2",
                                        Core_subs=new List<Subject>() {new Subject() { Sub_id=1,Sub_name="xya",Sub_code="abc",Curr_link="yyyyy"} },
                                        PE_subs = new List<Subject>() {new Subject() { Sub_id=2,Sub_name="xya",Sub_code="avfbc",Curr_link="yyyyy"} },
                                        OE_subs = new List<Subject>() {new Subject() { Sub_id=3,Sub_name="xya",Sub_code="asfd",Curr_link="yyyyy"} }
                                    }
                                }
                            },
                            new Course()
                            {
                                C_id=2,
                                Cname="CCE",
                                Semesters = new List<Semester>()
                                {
                                     new Semester()
                                    {
                                        S_id= "1",
                                        Core_subs=new List<Subject>() {new Subject() { Sub_id=1,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} },
                                        PE_subs = new List<Subject>() {new Subject() { Sub_id=2,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} },
                                        OE_subs = new List<Subject>() {new Subject() { Sub_id=3,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} }
                                    },
                                    new Semester()
                                    {
                                        S_id= "2",
                                        Core_subs=new List<Subject>() {new Subject() { Sub_id=1,Sub_name="xya",Sub_code="abc",Curr_link="yyyyy"} },
                                        PE_subs = new List<Subject>() {new Subject() { Sub_id=2,Sub_name="xya",Sub_code="avfbc",Curr_link="yyyyy"} },
                                        OE_subs = new List<Subject>() {new Subject() { Sub_id=3,Sub_name="xya",Sub_code="asfd",Curr_link="yyyyy"} }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new Institute()
            {
                Id = new ObjectId("3"),
                Name = "SOC",
                Departments = new List<Department>()
                {
                    new Department()
                    {
                        D_id=1,
                        Dname = "ABC",
                        Courses = new List<Course>()
                        {
                            new Course()
                            {
                                C_id=1,
                                Cname="ITa",
                                Semesters = new List<Semester>()
                                {
                                    new Semester()
                                    {
                                        S_id= "1",
                                        Core_subs=new List<Subject>() {new Subject() { Sub_id=1,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} },
                                        PE_subs = new List<Subject>() {new Subject() { Sub_id=2,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} },
                                        OE_subs = new List<Subject>() {new Subject() { Sub_id=3,Sub_name="xya",Sub_code="abc",Curr_link="sssss"} }
                                    },
                                    new Semester()
                                    {
                                        S_id= "2",
                                        Core_subs=new List<Subject>() {new Subject() { Sub_id=1,Sub_name="xya",Sub_code="abc",Curr_link="yyyyy"} },
                                        PE_subs = new List<Subject>() {new Subject() { Sub_id=2,Sub_name="xya",Sub_code="avfbc",Curr_link="yyyyy"} },
                                        OE_subs = new List<Subject>() {new Subject() { Sub_id=3,Sub_name="xya",Sub_code="asfd",Curr_link="yyyyy"} }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
        */
        public ChangeInCurriculumController()
        {
            _repositoryIns = new InstituteRepository();
            All_ins2 = _repositoryIns.GetInstitutes();
        }
       

        // GET: ChangeInCurriculum
        public ActionResult Index()
        {
            TempData["UserName3"] = TempData["UserName2"];
            ViewData["Uname"] = TempData["UserName2"];
            ViewBag.Uname = TempData["UserName2"];
            return View();
        }
        public static InstituteViewModal ivm = new InstituteViewModal(); 
        public ActionResult InstituteView()
        {
            ivm.InsList.Clear();
            foreach(Institute i in All_ins2)
            {
                ivm.InsList.Add(i);
            }
            return View(ivm);
        }
        public static DepartmentViewModal dvm = new DepartmentViewModal();
        public ActionResult DepartmentView(Double? InstituteID)
        {
            dvm.DeptList.Clear();
            Console.Write(InstituteID);
            System.Diagnostics.Debug.Write(InstituteID);
            Console.Write(All_ins2);
            System.Diagnostics.Debug.Write(All_ins2);
            /*if (ID== null)
                InstituteID = (ViewBag.Ins);*/
            if (InstituteID != null)
            {
                if(InstituteID == 123)
                {
                    goto x;
                }
                Institute i = All_ins2.Find(p => p.Ins_id.Equals(InstituteID));
                Console.Write(i);
                foreach(Department d in i.Departments)
                {
                    dvm.DeptList.Add(d);
                }
            x:
                ;
            }
            else
                System.Diagnostics.Debug.Write("INSTITUTEID = NULL");
                return View(dvm);
        }
        public static CourseViewModal cvm = new CourseViewModal();
        public ActionResult CourseView(Double? InstituteID , Double? DeptID)
        {
            cvm.CourseList.Clear();
            if(InstituteID!=null && DeptID != null)
            {
                if (InstituteID == 123)
                {
                    goto z;
                }
                Institute i = All_ins2.Find(p => p.Ins_id == InstituteID);
                Department d = i.Departments.Find(p => p.D_id == DeptID);
                foreach(Course c in d.Courses)
                {
                    cvm.CourseList.Add(c);
                }
            z:
                ;
            }
            return View(cvm);
        }

        public static SemesterViewModal svm = new SemesterViewModal();

        public ActionResult SemesterView(Double? InstituteID,Double? DeptID, Double? CourseID)
        {
            svm.SemesterList.Clear();
            if (InstituteID != 123 && DeptID != null && CourseID != null)
            {
                Institute i = All_ins2.Find(p => p.Ins_id == InstituteID);
                Department d = i.Departments.Find(p => p.D_id == DeptID);
                Course c = d.Courses.Find(p => p.C_id == CourseID);
                foreach (Semester s in c.Semesters)
                {
                    svm.SemesterList.Add(s);
                }
            }
            return View(svm);
        }
        public static SubjectViewModal suvm = new SubjectViewModal();
        public ActionResult SubjectView(Double? InstituteID, Double? DeptID, Double? CourseID,Double? SemesterID, Double? Sub_type)
        {
            suvm.SubjectList.Clear();
            if(InstituteID!=123 && DeptID!=null &&  CourseID!=null && SemesterID!=null && Sub_type!=null)
            {
                Institute i = All_ins2.Find(p => p.Ins_id == InstituteID);
                Department d = i.Departments.Find(p => p.D_id == DeptID);
                Course c = d.Courses.Find(p => p.C_id == CourseID);
                //ToDouble(SemesterID);
                
                Semester s = c.Semesters.Find(p => Double.Parse(p.S_id) == SemesterID);
                if (Sub_type == 1)
                {
                    suvm.SubjectList = s.Core_subs;
                }
                else if (Sub_type == 2)
                {
                    suvm.SubjectList = s.PE_subs;
                }
                else
                    suvm.SubjectList = s.OE_subs;
            }
            return View(suvm);
        }
        public ActionResult Modify()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("Modify");
        }
    }
}