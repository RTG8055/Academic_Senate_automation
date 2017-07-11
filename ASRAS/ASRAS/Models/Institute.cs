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
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
    }
    public class Department
    {
        public Department()
        {
            this.Courses = new List<Course>();
        }
        public string Dname { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Course
    {
        public Course()
        {
            this.Semesters = new List<Semester>();
        }
        public string Cname { get; set; }
        public List<Semester> Semesters { get; set; }
    }
    public class Semester
    {
        public Semester()
        {
            this.Core_subs = new List<Core_sub>();
            this.PE_subs = new List<PE_sub>();
            this.OE_subs = new List<OE_sub>();
        }
        public string S_id { get; set; }
        public List<Core_sub> Core_subs { get; set; }
        public List<PE_sub> PE_subs { get; set; }
        public List<OE_sub> OE_subs { get; set; }
    }
    public class Core_sub
    {
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
    }
}