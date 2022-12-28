using Projeveritabanıdeneme.Models.EntityFramework;
using Projeveritabanıdeneme.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeveritabanıdeneme.Controllers
{
    [Authorize]
    public class ÖğrenciController : Controller
    {
        proje1Entities db = new proje1Entities();

        // GET: Öğrenci
        public ActionResult Index()
        {
            var model=db.Akademik_Ders_Öğrenci.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Kaydet3(Akademik_Ders_Öğrenci ders)
        {

         
                db.Akademik_Ders_Öğrenci.Add(ders);

           

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersKayıt()
        {
            var model = new DanismanUzmanlıkController()
            {
                Öğrenci=db.Öğrenci.ToList(),
                Akademikders = db.Akademik_Ders.ToList()

            };
            return View("DersKayıt", model);
        }
      
    }
}