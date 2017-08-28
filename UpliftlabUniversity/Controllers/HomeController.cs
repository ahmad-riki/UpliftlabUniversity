using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpliftlabUniversity.DAL;
using UpliftlabUniversity.Models;
using UpliftlabUniversity.ViewModels;

namespace UpliftlabUniversity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private SchoolContext db = new SchoolContext();
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            var data = from student in db.Students
                       group student by student.EnrollmentDate into dateGroup
                       select new EnrollmentDateGroup()
                       {
                EnrollmentDate = dateGroup.Key, StudentCount = dateGroup.Count()
            };
            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}