using ProyectoIPC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ProyectoIPC2.Controllers
{
    public class TorneoOthelloController : Controller
    {
        static string  Nombre_torneo="";
        static string cantidad = "";
        static List<string> Equipos = new List<string>();
        static List<string> Integrantes = new List<string>();

        static List<string> EInequipoA = new List<string>();
        static List<string> InequipoB = new List<string>();
        static string EquipoA = "";
        static string EquipoB = "";
        static string E1= "";
        static string E2 = "";
        static string E3 = "";
        static string E4 = "";
        static string E5 = "";
        static string E6 = "";
        static string E7 = "";
        static string E8 = "";
        static string E91 = "";
        static string E92 = "";
        static string E93 = "";
        static string E94 = "";
        static string E95 = "";
        static string E96 = "";
        static string E97 = "";
        static string E98 = "";
        static string E11 = "";
        static string E12 = "";
        static string E13 = "";
        static string E14 = "";
        static string E15 = "";
        static string E16 = "";
        static string E17 = "";
        static string E18 = "";
        static string E111 = "";
        static string E112 = "";
        static string E113 = "";
        static string E114 = "";


        // GET: TorneoOthello
        public ActionResult Index()
        {
            
            return View();
        }


        //-------------------------  RECIBE DEL TABLERO Y MANDA LOS EQUIPOS A A JUGAR, CON LA VISTA INDEX ------------
        [HttpPost]
        public ActionResult Index(string a)
        {
            equipos(a);


            return RedirectToAction("Index");
        }
        //-----------------------------------------------------------------------------------------------------------------



        // ------------------------------------------------- CARGAR ARCHIVOS DE TORNEO XML -----------------------------------------
        [HttpPost]
        public ActionResult Cargarxml(HttpPostedFileBase file)
        {
            List<int> listado = new List<int>();
            List<String> colores = new List<String>();
            Torneo datos = new Torneo();
            Torneo equipos = new Torneo();

            if (file != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file.InputStream);
                foreach (XmlNode node in doc.SelectNodes("/campeonato"))
                {
                    Nombre_torneo = node["nombre"].InnerText;
                }

              foreach (XmlNode node in doc.SelectNodes("/campeonato/equipo"))
                {
                    string nombreEquipo = node["nombreEquipo"].InnerText;
                   
                    Equipos.Add(nombreEquipo);
                   
                }
                int i = 1;
                int j = 1;
                int cont = 3;
                while ( doc.DocumentElement.ChildNodes[i]!=null) {
                    string jugador = doc.DocumentElement.ChildNodes[i].ChildNodes[j].ChildNodes[0].Value;
                    Integrantes.Add(jugador);
                    if (j == cont)
                    {
                        
                        i += 1;
                        j = 1;
                    }
                    else {
                        j += 1;
                    }
                }
            }

            AsignacionInicial();
            return RedirectToAction("Tablero");
        }


        //-------------------------------------------- REDIRIGE AL TABLERO DONDE SE ENCUENTRA EL DIAGRAMA ---------------------
        public ActionResult Tablero() {

            ViewBag.E111 = E111;
            ViewBag.E112 = E112;
            ViewBag.E113 = E113;
            ViewBag.E114 = E114;
            ViewBag.E11 = E11;
            ViewBag.E12 = E12;
            ViewBag.E13 = E13;
            ViewBag.E14 = E14;
            ViewBag.E15 = E15;
            ViewBag.E16 = E16;
            ViewBag.E17 = E17;
            ViewBag.E18 = E18;
            ViewBag.E1 = E1;
            ViewBag.E2 = E2;
            ViewBag.E3 = E3;
            ViewBag.E4 = E4;
            ViewBag.E5= E5;
            ViewBag.E6 = E6;
            ViewBag.E7 = E7;
            ViewBag.E8 = E8;
            ViewBag.E91 = E91;
            ViewBag.E92 = E92;
            ViewBag.E93 = E93;
            ViewBag.E94 = E94;
            ViewBag.E95 = E95;
            ViewBag.E96 = E96;
            ViewBag.E97 = E97;
            ViewBag.E98 = E98;

            ViewBag.Nombre_Torneo = Nombre_torneo;
            ViewBag.Equipos = Equipos;
            ViewBag.Integrantes = Integrantes;
            ViewBag.Cantidad = cantidad;

            return View();
        }



        public void AsignacionInicial()
        {
            if (Equipos.Count() == 4)
            {
                E111 = Equipos[0];
                E112 = Equipos[1];
                E113 = Equipos[2];
                E114 = Equipos[3];

            }
            else if (Equipos.Count() == 8)
            {
                E11 = Equipos[0];
                E12 = Equipos[1];
                E13 = Equipos[2];
                E14 = Equipos[3];
                E15 = Equipos[4];
                E16 = Equipos[5];
                E17 = Equipos[6];
                E18 = Equipos[7];

            }
            else if (Equipos.Count() == 16)
            {
                E1 = Equipos[0];
                E2 = Equipos[1];
                E3 = Equipos[2];
                E4 = Equipos[3];
                E5 = Equipos[4];
                E6 = Equipos[5];
                E7 = Equipos[6];
                E8 = Equipos[7];
                E91 = Equipos[8];
                E92 = Equipos[9];
                E93 = Equipos[10];
                E94 = Equipos[11];
                E95 = Equipos[12];
                E96 = Equipos[13];
                E97 = Equipos[14];
                E98 = Equipos[15];
            }
        }


        //------------------------------------------ AUXILIA AL METODO HTTP POST CON LOS VALORES -----------------------------------
        public void equipos(string b) {
            if (b == "1") {
                EquipoA = E1;
                EquipoB = E2;
            } else if (b == "2") {
                EquipoA = E3;
                EquipoB = E4;
            }else if (b == "3") {
                EquipoA = E5;
                EquipoB = E6;
            } else if (b == "4")
            {
                EquipoA = E7;
                EquipoB = E8;
            }
            else if (b == "5")
            {
                EquipoA = E11;
                EquipoB = E12;
            }
            else if (b == "6")
            {
                EquipoA = E13;
                EquipoB = E14;
            }
            else if (b == "7")
            {
                EquipoA = E111;
                EquipoB = E112;
            }
            else if (b == "8")
            {
                EquipoA = E113;
                EquipoB = E114;
            }
            else if (b == "9")
            {
                EquipoA = E15;
                EquipoB = E16;
            }
            else if (b == "10")
            {
                EquipoA = E17;
                EquipoB = E18;
            }
            else if (b == "11")
            {
                EquipoA = E91;
                EquipoB = E92;
            }
            else if (b == "12")
            {
                EquipoA = E93;
                EquipoB = E94;
            }
            else if (b == "13")
            {
                EquipoA = E95;
                EquipoB = E96;
            }
            else if (b == "14")
            {
                EquipoA = E97;
                EquipoB = E98;
            }


        }


    }
}