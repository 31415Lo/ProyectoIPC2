using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class OthelloxtrColoresController : Controller
    {
        // GET: OthelloxtrColores
        public ActionResult Index()
        {
            return View();
        }

        //string negro, string rojo, string col3, string col4, string col5,string columna,string fila, string col6, string col7, string col8, string col9, string col10

        [HttpPost]
        public ActionResult Index(FormCollection form, IList<int> color1,string color2, int columnas, int filas )
        {
            int col = columnas;
            for (int i=0;i<color1.Count();i++) {
                if (color1[i] == 1)
                {
                    int negro = color1[i];
                }
                else if (color1[i] == 2) {
                    int rojo = color1[i];
                }
               
            };

            
          

            return View();
        }
    }
}