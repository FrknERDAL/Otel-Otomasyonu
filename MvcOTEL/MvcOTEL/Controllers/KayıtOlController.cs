using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
namespace MvcOTEL.Controllers
{
    public class KayıtOlController : Controller
    {
        // GET: KayıtOl
        OtelEntities db = new OtelEntities();
        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(TBLMUSTERI p) 
        {
            if (!ModelState.IsValid)
            {
                return View("Kayıt");
            }
            db.TBLMUSTERI.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}