using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxActionLinks.Data;
using Microsoft.AspNetCore.Mvc;
using AjaxActionLinks.Models;

namespace AjaxActionLinks.Controllers
{
    public class StudentsController : Controller
    {

        SchoolDBContext studentDbContext;
        public StudentsController(SchoolDBContext _studentDbContext)
        {
            studentDbContext = _studentDbContext;
        }
        public IActionResult Index()
        {
            var students = studentDbContext.Students;
            return View(students);
        }



        [HttpGet]
        public IActionResult AjaxDelete(int id)
        {
            var student = studentDbContext.Students.Find(id);
            studentDbContext.Remove<Student>(student);
            studentDbContext.SaveChanges();
            var students = studentDbContext.Students;
            return PartialView(students);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = studentDbContext.Students.Find(id);
            return View(student);

            //return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AjaxEdit(int id)
        {
            var student = studentDbContext.Students.Find(id);
            return PartialView(student);

            //return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AjaxEdit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentDbContext.Update<Student>(student);
                studentDbContext.SaveChanges();
                var students = studentDbContext.Students;

                return PartialView("AjaxDelete", students);
            }
            return View();
        }


        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentDbContext.Update<Student>(student);
                studentDbContext.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View();
        }



        [HttpGet]
        public IActionResult AjaxCreate()
        {
            //var student = studentDbContext.Students.Find(id);
            return PartialView("AjaxEdit");

            //return RedirectToAction("Index");
        }

        



    }
}