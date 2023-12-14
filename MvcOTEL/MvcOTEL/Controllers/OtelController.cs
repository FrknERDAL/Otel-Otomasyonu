using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
namespace MvcOTEL.Controllers
{
    public class OtelController : Controller
    {
        // GET:
        OtelEntities db = new OtelEntities();
        public ActionResult Index(string p)
        {
            var odalar = from k in db.TBLOTEL select k;
            if (!string.IsNullOrEmpty(p))
            {
                odalar = odalar.Where(m => m.NO.Contains(p));
            }
           // var odalar = db.TBLOTEL.ToList();
            return View(odalar.ToList());
        }
        [HttpGet]
        public ActionResult OdaEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLSUBE.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
            public ActionResult OdaEkle(TBLOTEL p)
        {
            ViewBag.dgr = p.ID;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var sube = db.TBLSUBE.Where(y => y.ID == p.TBLSUBE.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.TBLSUBE = sube;
            db.TBLOTEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");          
        }
        public ActionResult OtelSil(int id)
        {
            var otel = db.TBLOTEL.Find(id);
            db.TBLOTEL.Remove(otel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}