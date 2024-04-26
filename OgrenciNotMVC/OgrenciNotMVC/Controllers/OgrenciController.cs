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
        public ActionResult Index()
        {
            var ogrenci = db.TblOgrenciler.ToList();
            return View(ogrenci);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> degerler = (from x in db.TblKulupler.ToList()
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

        public ActionResult Sil(int id)
        {
            var silinecekOgrenci = db.TblOgrenciler.Find(id);

            var notlar = db.TblNotlar.Where(n => n.OgrID == id);
            db.TblNotlar.RemoveRange(notlar);

            db.TblOgrenciler.Remove(silinecekOgrenci);

            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult OgrenciGetir(int id)
        {
            var guncellenecekOgrenci = db.TblOgrenciler.Find(id);

            List<SelectListItem> degerler = (from x in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KulupAd,
                                                 Value = x.KulupID.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;

            return View(nameof(OgrenciGetir), guncellenecekOgrenci);
        }
        public ActionResult Guncelle(TblOgrenciler p)
        {
            var ogrenci = db.TblOgrenciler.Find(p.OgrenciID);
            ogrenci.OgrAd = p.OgrAd;
            ogrenci.OgrSoyad = p.OgrSoyad;
            ogrenci.OgrFotograf = p.OgrFotograf;
            ogrenci.OgrCinsiyet = p.OgrCinsiyet;
            ogrenci.OgrKulup = p.OgrKulup;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}