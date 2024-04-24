using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntitiyFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci 
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        List<SelectListItem> degerler = new List<SelectListItem>();
        public ActionResult Index()
        {
            var ogrenci = db.TblOgrenciler.ToList();
            return View(ogrenci);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            degerler = (from x in db.TblKulupler.ToList()
                        select new SelectListItem
                        {
                            Text = x.KulupAd,
                            Value = x.KulupID.ToString()
                        }).ToList();
            ViewBag.deger = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(TblOgrenciler p)
        {
            var kulup = db.TblKulupler.Where(k => k.KulupID == p.TblKulupler.KulupID).FirstOrDefault();
            p.TblKulupler = kulup;
            db.TblOgrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}