using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models;
using OgrenciNotMVC.Models.EntitiyFramework;


namespace OgrenciNotMVC.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.TblNotlar.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TblNotlar p)
        {
            db.TblNotlar.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult NotGetir(int id)
        {
            var guncellenecekNot = db.TblNotlar.Find(id);
            return View(nameof(NotGetir), guncellenecekNot);
        }
        [HttpPost]
        public ActionResult NotGetir(TblNotlar p, int proje, Class1 model, int sinav1 = 0, int sinav2 = 0, int sinav3 = 0)
        {
            if (model.islem == "Hesapla")
            {
                //islem1
                decimal ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;

                ViewBag.ort = ortalama;

            }
            else if (model.islem == "NotGuncelle")
            {
                //islem2
                var notlar = db.TblNotlar.Find(p.NotID);
                notlar.Sinav1 = p.Sinav1;
                notlar.Sinav2 = p.Sinav2;
                notlar.Sinav3 = p.Sinav3;
                notlar.Proje = p.Proje;
                notlar.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
