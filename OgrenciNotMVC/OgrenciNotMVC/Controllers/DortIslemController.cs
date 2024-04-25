using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVC.Controllers
{
    public class DortIslemController : Controller
    {
        // GET: DortIslem
        public ActionResult Index(double s1=0, double s2 =0)
        {
            double toplama = s1+s2;
            double cikarma = s1-s2;
            double carpma = s1*s2;
            double bolme = s1/s2;
            ViewBag.toplama = toplama;
            ViewBag.cikarma = cikarma;
            ViewBag.carpma = carpma;
            ViewBag.bolme = bolme;
            return View();
        }
    }
}