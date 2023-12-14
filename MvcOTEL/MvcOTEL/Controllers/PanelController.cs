using MvcOTEL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOTEL.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        OtelEntities db = new OtelEntities();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var müsterim = (string)Session["MAIL"];
            var degerler = db.TBLMUSTERI.FirstOrDefault(z => z.MAIL == müsterim);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBLMUSTERI p)
        {
            var kullanıcı = (string)Session["MAIL"];
            var uye = db.TBLMUSTERI.FirstOrDefault(x => x.MAIL == kullanıcı);
            uye.SIFRE = p.SIFRE;
            uye.ADI = p.ADI;
            uye.SOYAD = p.SOYAD;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return View();
        }
        public ActionResult odalarım()
        {
            var müsteri = (string)Session["MAIL"];
            var id = db.TBLMUSTERI.Where(x => x.MAIL == müsteri.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.ÜYE == id).ToList();
            return View(degerler);
        }
    }
}