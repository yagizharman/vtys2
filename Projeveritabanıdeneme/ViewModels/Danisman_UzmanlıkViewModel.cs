using Projeveritabanıdeneme.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeveritabanıdeneme.ViewModels
{
    public class Danisman_UzmanlıkViewModel : Controller
    {
        // GET: Danisman_Uzmanlık
        public IEnumerable<Danışman> Danışman { get; set; }
        public IEnumerable<Uzmanlık_Alanı> UzmanlıkAlanı { get; set; }
        public Kullanıcı Kullanıcı { get; set; }
        public Öğrenci Öğrenci { get; set; }
        public IEnumerable<Kullanıcı> Kullanıcı2 { get; set; }
        public Danışman Danışman2 { get; set; }   
        public Akademik_Ders Akademikders { get; set; }
        public IEnumerable<SelectListItem> isimler { get; set; }
        public IEnumerable<Akademik_Dönem> AkademikDonem { get; set; }
        public  Ders_Ekleme_Çıkarma Ders_Ekleme_Çıkarma { get; set; }
     
    }
}