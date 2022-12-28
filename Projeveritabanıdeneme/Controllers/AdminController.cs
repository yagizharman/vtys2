using Projeveritabanıdeneme.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Projeveritabanıdeneme.ViewModels;
using System.Data.SqlClient;

namespace Projeveritabanıdeneme.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        proje1Entities db=new proje1Entities();
        // GET: Admin
        public ActionResult Index(string searching)//Danışman
        {
            var model1 = db.Danışman.Include(s => s.Kullanıcı);
            model1 = db.Danışman.Include(s => s.Akademik_Ders);
            model1 = db.Danışman.Include(s => s.Uzmanlık_Alanı);

            model1 = from s in db.Danışman
                     where s.Psf_Id == 1
                     select s;
                        if(!String.IsNullOrEmpty(searching))
            {
                model1=model1.Where(s=>s.Danışman_Ad.Contains(searching));
            }
            
            return View(model1.ToList());
        }



        [HttpPost]
        public ActionResult Kaydet(Danışman danışman)
        {
           
            if (danışman.Danışman_Id == 0)
            {
                db.Danışman.Add(danışman);
                danışman.Psf_Id = 1;
            }
            else
            {
                var guncellenecekDanışman = db.Danışman.Find(danışman.Danışman_Id);
                if (guncellenecekDanışman == null)
                {
                    return HttpNotFound();
                }
                   guncellenecekDanışman.Danışman_Ad = danışman.Danışman_Ad;
                    guncellenecekDanışman.Danışman_Soyad = danışman.Danışman_Soyad;
                    guncellenecekDanışman.Kullanıcı.TC_No = danışman.Kullanıcı.TC_No;
                    guncellenecekDanışman.Danışman_Uyruğu = danışman.Danışman_Uyruğu;
                    guncellenecekDanışman.Uzmanlık_Başlama_Tarihi = danışman.Uzmanlık_Başlama_Tarihi;
                    guncellenecekDanışman.Unvan = danışman.Unvan;
                    guncellenecekDanışman.Danışman_Doğum_Tarihi = danışman.Danışman_Doğum_Tarihi;
                    guncellenecekDanışman.Danışman_Doğum_Yeri = danışman.Danışman_Doğum_Yeri;
                    guncellenecekDanışman.Kullanıcı.Kullanıcı_Adı = danışman.Kullanıcı.Kullanıcı_Adı;
                    guncellenecekDanışman.Kullanıcı.Mail = danışman.Kullanıcı.Mail;
                    guncellenecekDanışman.Kullanıcı.Parola = danışman.Kullanıcı.Parola;
                    guncellenecekDanışman.Uzmanlık_ıd = danışman.Uzmanlık_ıd;
                    guncellenecekDanışman.Kullanıcı.Tel = danışman.Kullanıcı.Tel;
                    guncellenecekDanışman.Kullanıcı.Rol = danışman.Kullanıcı.Rol;
                
            }
            db.SaveChanges();
          return RedirectToAction("Index");
        }
        public ActionResult Guncelle3(int id)
        {
            var model = new DanismanUzmanlıkController()
            {
                UzmanlıkAlanı = db.Uzmanlık_Alanı.ToList(),
                Danışman = db.Danışman.Find(id)
            };
            return View("Kaydet", model);

        }
        public ActionResult Yenidanisman()
        {
            var model = new DanismanUzmanlıkController()
            {
                UzmanlıkAlanı = db.Uzmanlık_Alanı.ToList()

            };
            return View("Kaydet", model);
        }
        public ActionResult SilPersonel(int id)
        {
            var silinecekDanisman = db.Danışman.Find(id);
            if (silinecekDanisman == null)
            {
                return HttpNotFound();
            }
            silinecekDanisman.Psf_Id = 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index2(string searching)//Öğrenci
        {
            var model1 = db.Öğrenci.Include(s => s.Uzmanlık_Alanı);
            model1 = db.Öğrenci.Include(s => s.Kullanıcı);
            model1 = from s in db.Öğrenci
                     where s.Psf_Id==1
                     select s;
            if (!String.IsNullOrEmpty(searching))
            {
                model1 = model1.Where(s => s.Öğrenci_Ad.Contains(searching));
            }
            return View(model1.ToList());
        }
        public ActionResult Yeni()
        {
            var model = new Danisman_UzmanlıkViewModel()
            {
                Danışman= db.Danışman.ToList(),
                UzmanlıkAlanı = db.Uzmanlık_Alanı.ToList(),
             
            };
            return View("ÖğrenciForm", model);
        }

        [HttpPost]
        public ActionResult Kaydet2(Öğrenci öğrenci)  
        {

            if (öğrenci.Öğrenci_Id == 0)
            {
                db.Öğrenci.Add(öğrenci);
                öğrenci.Psf_Id = 1;
            }
            else
            {
                //db.Entry(öğrenci).State = System.Data.Entity.EntityState.Modified;
                var guncelogrenci = db.Öğrenci.Find(öğrenci.Öğrenci_Id);
                if (guncelogrenci == null)
                {
                    return HttpNotFound();
                }
                guncelogrenci.Öğrenci_Ad = öğrenci.Öğrenci_Ad;
                guncelogrenci.Öğrenci_Uyruğu = öğrenci.Öğrenci_Uyruğu;
                guncelogrenci.Öğrenci_Soyad = öğrenci.Öğrenci_Soyad;
                guncelogrenci.Öğrenci_DUS_Puanı = öğrenci.Öğrenci_DUS_Puanı;
                guncelogrenci.Öğrenci_Doğum_Yeri = öğrenci.Öğrenci_Doğum_Yeri;
                guncelogrenci.Öğrenci_Doğum_Tarihi = öğrenci.Öğrenci_Doğum_Tarihi;
                guncelogrenci.Uzmanlık_Id = öğrenci.Uzmanlık_Id;
                guncelogrenci.Uzmanlık_Eğitimi_Başlama_Tarihi = öğrenci.Uzmanlık_Eğitimi_Başlama_Tarihi;
                guncelogrenci.Uzmanlık_Eğitimi_Tamamlama_Tarihi = öğrenci.Uzmanlık_Eğitimi_Tamamlama_Tarihi;
                guncelogrenci.Kullanıcı.Kullanıcı_Adı = öğrenci.Kullanıcı.Kullanıcı_Adı;
                guncelogrenci.Kullanıcı.TC_No = öğrenci.Kullanıcı.TC_No;
                guncelogrenci.Kullanıcı.Mail = öğrenci.Kullanıcı.Mail;
                guncelogrenci.Kullanıcı.Parola = öğrenci.Kullanıcı.Parola;
                guncelogrenci.Kullanıcı.Rol = öğrenci.Kullanıcı.Rol;
                guncelogrenci.Kullanıcı.Tel = öğrenci.Kullanıcı.Tel;
                guncelogrenci.Danışman_Id = öğrenci.Danışman_Id;

            }
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new Danisman_UzmanlıkViewModel()
            {       
                Danışman = db.Danışman.ToList(),
                UzmanlıkAlanı = db.Uzmanlık_Alanı.ToList(),
                Kullanıcı2 = db.Kullanıcı.ToList(),
                Öğrenci = db.Öğrenci.Find(id)
            };
            return View("ÖğrenciForm",model);
        }
        public ActionResult SilOgrenci(int id)
        {
            var silinecekÖğrenci=db.Öğrenci.Find(id);
            if(silinecekÖğrenci == null)
            {
                return HttpNotFound();
            }
            silinecekÖğrenci.Psf_Id = 0;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult Index3(string searching)//Akademik_Ders
        {
            var model1 = db.Akademik_Ders.Include(s => s.Uzmanlık_Alanı);
            model1 = db.Akademik_Ders.Include(s => s.Danışman);
            model1 = from s in db.Akademik_Ders
                     where s.Psf_Id == 1
                     select s;
            if (!String.IsNullOrEmpty(searching))
            {
                model1 = model1.Where(s => s.Ders_Tanımı.Contains(searching));
            }
            return View(model1.ToList());
        }
        [HttpPost]
        public ActionResult Kaydet3(Akademik_Ders ders)
        {

            if (ders.Akademik_Ders_Id == 0)
            {
                db.Akademik_Ders.Add(ders);
                ders.Psf_Id = 1;
            }
            else
            {
                //db.Entry(öğrenci).State = System.Data.Entity.EntityState.Modified;
                var guncelders = db.Akademik_Ders.Find(ders.Akademik_Ders_Id);
                if (guncelders == null)
                {
                    return HttpNotFound();
                }
                guncelders.Ders_Tanımı = ders.Ders_Tanımı;
                guncelders.Ders_Kod = ders.Ders_Kod;
                guncelders.KREDI = ders.KREDI;
                guncelders.TUR_ID = ders.TUR_ID;
                guncelders.Uzmanlık_Alanı.Uzmanlık_Ad = ders.Uzmanlık_Alanı.Uzmanlık_Ad;
                guncelders.AKTS = ders.AKTS;
                guncelders.DIL_ID = ders.DIL_ID;
                guncelders.Danışman_Id = ders.Danışman_Id;


            }
            db.SaveChanges();
            return RedirectToAction("Index3");
        }
        public ActionResult Guncelleders(int id)
        {
            
            var model = new Danisman_UzmanlıkViewModel()
            {
                UzmanlıkAlanı = db.Uzmanlık_Alanı.ToList(),
                Danışman=db.Danışman.ToList(),
                Akademikders = db.Akademik_Ders.Find(id)
            };
            return View("DersKaydet", model);
        }
        public ActionResult Yeniders()
        {
            var model = new Danisman_UzmanlıkViewModel()
            {
                UzmanlıkAlanı = db.Uzmanlık_Alanı.ToList(),
                AkademikDonem=db.Akademik_Dönem.ToList(),
                Danışman = db.Danışman.ToList()

            };
            return View("DersKaydet", model);
        }
        public ActionResult SilAkademikDers(int id)
        {
            var silinecekDers = db.Akademik_Ders.Find(id);
            if (silinecekDers == null)
            {
                return HttpNotFound();
            }
            silinecekDers.Psf_Id = 0;
            db.SaveChanges();
            return RedirectToAction("Index3");
        }

    }
}