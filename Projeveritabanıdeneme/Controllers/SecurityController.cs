using Projeveritabanıdeneme.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeveritabanıdeneme.Controllers
{
   
    public class SecurityController : Controller
    {
        proje1Entities vtys2=new proje1Entities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanıcı kullanıcı)
        {

            var kullanıcıIn = vtys2.Kullanıcı.FirstOrDefault(x => x.Kullanıcı_Adı == kullanıcı.Kullanıcı_Adı
            && x.Parola == kullanıcı.Parola);
            if (kullanıcıIn != null)
            {
                FormsAuthentication.SetAuthCookie(kullanıcıIn.Kullanıcı_Adı, false);
                return RedirectToAction("Index2", "Admin");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı,Şifre veya Rol";
                return View();
            }


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}