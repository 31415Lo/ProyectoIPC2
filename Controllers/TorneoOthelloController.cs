using ProyectoIPC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class TorneoOthelloController : Controller
        
    {
        static List<Torneo> casillas = new List<Torneo>();

        // GET: TorneoOthello
        public ActionResult Index()
        {
            for (int i=0;i<64;i++) {
                Torneo lec = new Torneo();
                lec.Index = 0;
                casillas.Add(lec);
            }

            
            return View();
        }
    }
}