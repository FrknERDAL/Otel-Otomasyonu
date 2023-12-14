using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOTEL.Models.Entity;
using System.Web.Security;
namespace MvcOTEL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        OtelEntities db=new OtelEntities();
        public ActionResult GirisY()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisY(TBLMUSTERI p)
        {
            var bilgi = db.TBLMUSTERI.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.MAIL, false);
                Session["MAIL"] = bilgi.MAIL.ToString();
                //TempData["ADI"] = bilgi.ADI.ToString();
                //TempData["SOYAD"] = bilgi.SOYAD.ToString();
                //TempData["KullanıcıAdı"] = bilgi.KULLANICIADI.ToString();
                //TempData["Şifre"] = bilgi.SIFRE.ToString();
                //TempData["Telefon"] = bilgi.TELEFON.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            } 
        }
    }
}