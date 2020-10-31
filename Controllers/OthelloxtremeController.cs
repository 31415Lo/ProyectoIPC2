using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class OthelloxtremeController : Controller
    {
        static int col = 0;
        static int fil = 0;
        static string col1 = "";
        static string col2 = "";
        static string col3 = "";
        static string col4 = "";
        static string col5 = "";
        static string col6 = "";
        static string col7 = "";
        static string col8 = "";
        static string col9 = "";
        static string col10 = "";


        // GET: Othelloxtreme
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(IList<int> color1, IList<int> color2, int columnas, int filas)
        {
            col = columnas;
            fil = filas;
            for (int i = 0; i < color1.Count(); i++)
            {
                if (color1[i] == 1)
                {
                   col1 = "negro";
                }
                else if (color1[i] == 2)
                {
                    col2 = "rojo";
                }
                else if (color1[i] == 3)
                {
                    col3 = "amarillo";
                }
                else if (color1[i] == 4)
                {
                    col4 = "azul";
                }
                else if (color1[i] == 5)
                {
                    col5 = "anaranjado";
                }
            }
            for (int i = 0; i < color2.Count(); i++)
            {
                if (color1[i] == 6)
                {
                    col6 = "blanco";
                }
                else if (color1[i] == 7)
                {
                    col7 = "verde";
                }
                else if (color1[i] == 8)
                {
                    col8 = "violeta";
                }
                else if (color1[i] == 9)
                {
                    col9 = "celeste";
                }
                else if (color1[i] == 10)
                {
                    col10 = "gris";
                }
            }




            return View();
        }
    }
}