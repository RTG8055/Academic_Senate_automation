using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;

namespace ASRAS.Models
{
    public class InstituteRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<Institute> _collection;

        public InstituteRepository()
        {
            //if any error
            //__client = new MongoClient("mongodb//localhost");
            _client = new MongoClient();
            _database = _client.GetDatabase("AcademicSenate");
            _collection = _database.GetCollection<Institute>("All_institutes");
        }
        //Functions need to be added

        /*public Institute GetInstitute(string Ins_name)
        {
            Institute Ins = this._collection.Find(new BsonDocument { { "Name", Ins_name } }).FirstAsync().Result;
            return Ins;
        }*/
        //public List<string> GetInstitutes()
        public List<Institute> GetInstitutes()
        {
            //function to get the list of all the institutes
            //modifed------------------//function to get the list of institutes in string format
            var ALL = this._collection.Find(new BsonDocument()).ToListAsync();
            //List<string> Ins_names = new List<string>();
            List<Institute> Ins_List = new List<Institute>();
            
            foreach (Institute i in ALL.Result)
            {
                //Ins_names.Add(i.Name.ToString());
                Ins_List.Add(i);
            }
            //return Ins_names;
            return Ins_List;
        }
        public List<string> GetDepts(string Ins_name)
        {
            //function to get the list of departments in an institute for filling the dropbox once the institute is chosen
            Institute Ins = this._collection.Find(new BsonDocument { { "Name", Ins_name } }).FirstAsync().Result;
            List<string> Dept_names = new List<string>();
            foreach (Department d in Ins.Departments)
            {
                Dept_names.Add(d.Dname.ToString());
            }
            return Dept_names;
        }
        public List<string> GetCourses(string Ins_name,string Dept_name)
        {
            //function to get the list of courses in a department of an institute for the dropbox once the department in also chosen
            Institute Ins = this._collection.Find(new BsonDocument { { "Name", Ins_name } }).FirstAsync().Result;
            List<string> Course_names = new List<string>();
            foreach (Department D in Ins.Departments)
            {
                if(D.Dname.Equals(Dept_name))
                {
                    foreach(Course c in D.Courses)
                    {
                        Course_names.Add(c.Cname.ToString());
                    }
                }
            }
            return Course_names;
        }
        public List<string> GetSemesters(string Ins_name, string Dept_name,string Course_name)
        {
            //fucntion to get the list of available semesters in the course /*same as above*/
            Institute Ins = this._collection.Find(new BsonDocument { { "Name", Ins_name } }).FirstAsync().Result;
            List<string> Semester_numbers = new List<string>();
            foreach (Department D in Ins.Departments)
            {
                if (D.Dname.Equals(Dept_name))
                {
                    foreach (Course c in D.Courses)
                    {
                        if (c.Cname.Equals(Course_name))
                        {
                            foreach(Semester s in c.Semesters)
                            {
                                Semester_numbers.Add(s.S_id.ToString());
                            }
                        }
                    }
                }
            }
            return Semester_numbers;
        }
        public Semester GetSemester(string Ins_name, string Dept_name, string Course_name,string Sem)
        {
            //function to get the whole required semester
            Institute Ins = this._collection.Find(new BsonDocument { { "Name", Ins_name } }).FirstAsync().Result;
            foreach (Department D in Ins.Departments)
            {
                if (D.Dname.Equals(Dept_name))
                {
                    foreach (Course c in D.Courses)
                    {
                        if (c.Cname.Equals(Course_name))
                        {
                            foreach (Semester s in c.Semesters)
                            {
                                if(s.S_id.Equals(Sem))
                                {
                                    return s;
                                }
                            }
                        }
                    }
                }
            }
            return new Semester()
            {
                S_id = "Not Found"
            };
        }
    }
}