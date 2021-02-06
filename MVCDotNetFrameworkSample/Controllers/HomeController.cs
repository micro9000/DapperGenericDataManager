using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDotNetFrameworkSample.Models;
using MVCDotNetFrameworkSample.Services;

namespace MVCDotNetFrameworkSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentsData _studentsData;

        public HomeController(IStudentsData studentsData)
        {
            _studentsData = studentsData;
        }

        public ActionResult Index()
        {
            DisplayStudentModel model = new DisplayStudentModel();

            model.Students = _studentsData.GetAll();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}