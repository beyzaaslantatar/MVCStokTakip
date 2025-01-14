using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;


namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILERs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER m1 )
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILERs.Add(m1);
            db.SaveChanges(); 
            return View();
        }
        public ActionResult SIL(int id)
        {
            var sil = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir (int id)
        {
            var mus = db.TBLMUSTERILERs.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILERs.Find(p1.musteriID);
            mus.musteriAd = p1.musteriAd;
            mus.musteriSoyad = p1.musteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
   
}