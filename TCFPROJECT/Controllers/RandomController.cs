using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCFPROJECT.Controllers
{
    public class RandomController : Controller
    {
        public ActionResult Index() {
            ViewBag.Message = "This is some random shit";
            return View();
        }

    }
}