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
    public class DanışmanController : Controller
    {
        proje1Entities db = new proje1Entities();
        // GET: Danışman
        public ActionResult Index()
        {
            
            return View();
        }
       
      
       
    }
}