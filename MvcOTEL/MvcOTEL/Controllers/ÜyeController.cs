using MvcOTEL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MvcOTEL.Controllers
{
    public class ÜyeController : Controller
    {
        // GET: Üye
        OtelEntities db = new OtelEntities();
        public ActionResult Index(int sayfa = 1)
        {
            // var degerler = db.TBLMUSTERI.ToList();
           var degerler = db.TBLMUSTERI.ToList().ToPagedList(sayfa,  5);
            return View(degerler);
        }
        [HttpGet] 
        public ActionResult UyeEkle()
        {
            return View();
          
        }
        [HttpPost] 
        public ActionResult UyeEkle(TBLMUSTERI p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLMUSTERI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüsteriGeçmiş(int id) 
        {
            var odagcms = db.TBLHAREKET.Where(x => x.ÜYE == id).ToList();
            return View(odagcms);
        }
    }
}