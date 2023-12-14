using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
namespace MvcOTEL.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        OtelEntities db = new OtelEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLKATEGORI.Where(x => x.DURUM == true).ToList();
            return View(degerler);
            return View();
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            //db.TBLKATEGORI.Remove(kategori);
            kategori.DURUM= false;
            db.SaveChanges();
        
            return RedirectToAction("Index");
        }
    }
}