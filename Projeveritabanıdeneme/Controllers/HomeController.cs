using Projeveritabanıdeneme.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeveritabanıdeneme.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        proje1Entities db = new proje1Entities();
        // GET: Home
        public ActionResult Index()
        {
                      
            return View();
           
        }
    }
}