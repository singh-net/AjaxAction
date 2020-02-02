using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AjaxActionLinks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.MyDate = DateTime.Now.ToString();
            return View();
        }

        public PartialViewResult AjaxUpdate()
        {
            ViewBag.MyDate = DateTime.Now.ToString();
            return PartialView("PV_AjaxUpdate");
        
        }
    }
}