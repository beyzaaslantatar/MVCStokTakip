using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLERs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkleme()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkleme(TBLURUNLER u1)
        {
            //CALISMIYOR:(
            var ktg = db.TBLKATEGORILERs.Where(m=>m.kategoriID == u1.TBLKATEGORILER.kategoriID).FirstOrDefault();
            u1.TBLKATEGORILER=ktg;
            db.TBLURUNLERs.Add(u1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var sil = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLERs.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriID.ToString()
                                             }
                                            ).ToList();
            ViewBag.dgr = degerler;
            return View();

            return View("UrunGetir", urun);
        }
    }
 }