using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace ASRAS.Models
{
    public class Institute
    {
        public Institute()
        {
            this.Departments = new List<Department>();
        }
        public ObjectId Id { get; set; }
        public Double Ins_id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
    }
    public class Department
    {
        public Department()
        {
            this.Courses = new List<Course>();
        }
        public Int32 D_id { get; set; }
        public string Dname { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Course
    {
        public Course()
        {
            this.Semesters = new List<Semester>();
        }
        public Int32 C_id { get; set; }
        public string Cname { get; set; }
        public List<Semester> Semesters { get; set; }
    }
    public class Semester
    {
        public Semester()
        {
            this.Core_subs = new List<Subject>();
            this.PE_subs = new List<Subject>();
            this.OE_subs = new List<Subject>();
        }
        public string S_id { get; set; }
        public List<Subject> Core_subs { get; set; }
        public List<Subject> PE_subs { get; set; }
        public List<Subject> OE_subs { get; set; }
    }
    public class Subject
    {
        public Int32 Sub_id { get; set; }
        public string Sub_name { get; set; }
        public string Sub_code { get; set; }
        public string Curr_link { get; set; }
    }
    /*
    public class Core_sub
    {
        public Double Subid { get; set; }
        public string Sub_name { get; set; }
        public string Sub_code { get; set; }
        public string Curr_link { get; set; }
    }
    public class PE_sub
    {
        public string Sub_name { get; set; }
        public string Sub_code { get; set; }
        public string Curr_link { get; set; }
    }
    public class OE_sub
    {
        public string Sub_name { get; set; }
        public string Sub_code { get; set; }
        public string Curr_link { get; set; }
    }*/
}