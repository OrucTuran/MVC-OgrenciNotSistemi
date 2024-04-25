using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntitiyFramework;

namespace OgrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default => dersler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TblDersler.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TblDersler p)
        {
            db.TblDersler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var silinecekDers = db.TblDersler.Find(id);
            db.TblDersler.Remove(silinecekDers);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DersGetir(int id)
        {
            var guncellenecekDers = db.TblDersler.Find(id);
            return View(nameof(DersGetir), guncellenecekDers);
        }
    
    }
}