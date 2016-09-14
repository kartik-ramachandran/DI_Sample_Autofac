
using DIEngine;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISample.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            //the framework calls this
        }       

        public ActionResult Index()
        {
            var test = Ioc.IocContainer(typeof(ITraceRepository));
            ////var yes = _test.Trace();
            return View();
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