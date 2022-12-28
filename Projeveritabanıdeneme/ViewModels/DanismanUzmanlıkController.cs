using Projeveritabanıdeneme.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeveritabanıdeneme.ViewModels
{
    public class DanismanUzmanlıkController : Controller
    {
        // GET: DanismanUzmanlık
      
            public Danışman Danışman { get; set; }
            public IEnumerable<Uzmanlık_Alanı> UzmanlıkAlanı { get; set; }
            public Kullanıcı Kullanıcı { get; set; }
            public IEnumerable< Akademik_Ders> Akademikders { get; set; }
            public Akademik_Ders_Öğrenci Akademik_Ders_Öğrenci { get; set; }
            public IEnumerable<Öğrenci> Öğrenci { get; set; }

    }
}