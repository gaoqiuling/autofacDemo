using Qiuqiu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvctest.Controllers
{
    public class HomeController : Controller
    {
        ITest test;
        public HomeController(ITest itest)
        {
            test = itest;
        }
        public ActionResult Index()
        {
            ViewBag.Title = test.Add(1,1);

            return View();
        }
    }
}
