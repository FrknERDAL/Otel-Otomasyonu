using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
namespace MvcOTEL.Controllers
{
    public class KiralaController : Controller
    {
        // GET: Kirala
        OtelEntities db = new OtelEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Kirala()
        {
            List<SelectListItem> deger1 = (from x in db.TBLMUSTERI.ToList() select new SelectListItem { Text = x.ADI + " " + x.SOYAD, Value = x.ID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from y in db.TBLOTEL.Where(x=>x.DURUM == true).ToList() select new SelectListItem { Text = y.NO, Value = y.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult Kirala(TBLHAREKET p)
        {
            var d1 = db.TBLMUSTERI.Where(x => x.ID == p.TBLMUSTERI.ID).FirstOrDefault();
            var d2 = db.TBLOTEL.Where(y => y.ID == p.TBLOTEL.ID).FirstOrDefault();
            p.TBLMUSTERI = d1;
            p.TBLOTEL = d2;
            TimeSpan ts = (TimeSpan)(p.VERISTARIHI - p.ALISTARIH);
            TimeSpan ts2 = (TimeSpan)(p.ALISTARIH - DateTime.UtcNow.Date);
            if (ts2 < TimeSpan.Zero)
            {
                ViewBag.KiralamaError = "Veriler Eklenemedi. Tarihi kontrol ediniz.";
                return View();
            }
            if (ts <= TimeSpan.Zero)
            {
                ViewBag.TeslimError = "Veriler Eklenemedi. Tarihi kontrol ediniz.";
                return View();
            }
            p.ISLEMDURUM = false;
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OdaTeslim(int id)
        {
            var oda = db.TBLHAREKET.Find(id);
            return View("OdaTeslim", oda);
        }
        public ActionResult TeslimGüncel(TBLHAREKET p)
        {
            var tsl = db.TBLHAREKET.Find(p.ID);
            tsl.VERISTARIHI = p.VERISTARIHI;
            tsl.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}