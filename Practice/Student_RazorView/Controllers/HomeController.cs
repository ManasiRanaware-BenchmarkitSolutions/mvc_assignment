using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace viewdemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    


    public ActionResult StudentDetails()
    {
        ViewBag.StudentId = 101;
        ViewBag.StudentName = "Scott";
        ViewBag.Marks = 89;
        ViewBag.Noofsemesters = 6;
            ViewBag.Subjects = new List<string>() { "ENG", "Maths", "Science", "ART" };

        return View();
    }
}
}