using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JB.Sample.MvcSiteMap.Website.Areas.MainRole.Controllers
{
    public class JediController : Controller
    {
        public ActionResult LukeSkywalker()
        {
            ViewBag.Title = "Luke Skywalker";
            return View();
        }
        public ActionResult AnakinSkywalker()
        {
            ViewBag.Title = "Anakin Skywalkerr";
            return View();
        }

        public ActionResult LeiaSkywalker()
        {
            ViewBag.Title = "Leia Skywalker";
            return View();
        }
        public ActionResult Yoda()
        {
            ViewBag.Title = "Master Yoda";
            return View();
        }
        public ActionResult DarthVader()
        {
            ViewBag.Title = "Darth Vader";
            return View();
        }
        public ActionResult Palpatine()
        {
            ViewBag.Title = "Palpatine";
            return View();
        }
        public ActionResult HanSolo()
        {
            ViewBag.Title = "Han Solo";
            return View();
        }

    }
}
