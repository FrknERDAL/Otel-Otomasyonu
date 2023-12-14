using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
namespace MvcOTEL.Controllers
{
    public class ISLEMController : Controller
    {
        // GET: ISLEM
        OtelEntities db = new OtelEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}