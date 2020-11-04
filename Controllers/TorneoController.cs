using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class TorneoController : Controller
    {
        // GET: Torneo
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(int equipos)
        {

            
            return View();
        }

    }
}