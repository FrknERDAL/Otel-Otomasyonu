using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
namespace MvcOTEL.Controllers
{
    public class SubeController : Controller
    {
        // GET: Sube
        OtelEntities db=new OtelEntities();

        public ActionResult Index()
        {
            var değerler =db.TBLSUBE.ToList();
            return View(değerler);
        }
        [HttpGet] 
        public ActionResult ŞubeEkle() 
        {
            return View();
        }
       
        public ActionResult ŞubeEkle(TBLSUBE p)
        {
            db.TBLSUBE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult ŞubeSil(int id)
        {
            var şube = db.TBLSUBE.Find(id);
            db.TBLSUBE.Remove(şube);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}