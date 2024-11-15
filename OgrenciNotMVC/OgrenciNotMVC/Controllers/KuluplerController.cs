﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntitiyFramework;

namespace OgrenciNotMVC.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TblKulupler.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TblKulupler p)
        {
            db.TblKulupler.Add(p);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Sil(int id)
        {
            var silinecekKulup = db.TblKulupler.Find(id);
            db.TblKulupler.Remove(silinecekKulup);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult KulupGetir(int id)
        {
            var guncellenecekKulup = db.TblKulupler.Find(id);
            return View(nameof(KulupGetir), guncellenecekKulup);
        }
        public ActionResult Guncelle(TblKulupler p)
        {
            var kulup = db.TblKulupler.Find(p.KulupID);
            kulup.KulupAd = p.KulupAd;
            kulup.KulupKontenjan = p.KulupKontenjan;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}