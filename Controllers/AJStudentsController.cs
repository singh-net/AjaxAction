using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxActionLinks.Data;
using AjaxActionLinks.Models;

namespace AjaxActionLinks.Controllers
{

    [Produces("application/json")]
    public class AJStudentsController : Controller
    {
        SchoolDBContext SchoolDBContext;

        public AJStudentsController(SchoolDBContext _SchoolDBContext)
        {
            SchoolDBContext = _SchoolDBContext;
        }

        //public IActionResult GetStudents()
        //{
        //    var students = SchoolDBContext.Students;
        //    return Json(students);
        //}

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var students = SchoolDBContext.Students;
            return students;
        }

        [HttpGet]
        public Student GetStudentByID(int id)
        {
            var student = SchoolDBContext.Students.Find(id);
            return student;
        }

        [HttpPost]
        public string UpdateStudent(Student student)
        {
            //var student = SchoolDBContext.Students.Find(id);
            SchoolDBContext.Update<Student>(student);
            SchoolDBContext.SaveChanges();
            return "UPDATED";
            
            
        }

        [HttpPost]
        public string CreateStudent(Student student)
        {
            //var student = SchoolDBContext.Students.Find(id);
            SchoolDBContext.Add < Student>(student);
           // SchoolDBContext.Update<Student>(student);
            SchoolDBContext.SaveChanges();
            return "Created";


        }
    }
}