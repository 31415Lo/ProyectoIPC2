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
        static List<int> Punteos = new List<int>();

        static List<string> InequipoA = new List<string>();
        static List<string> InequipoB = new List<string>();
        static string Aviso = "";
        static string EquipoA = "";
        static string EquipoB = "";
        static string Juego = "";
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
        static string Final1 = "";
        static string Final2 = "";
        static string Final = "";


        // GET: TorneoOthello
        public ActionResult Index()
        {
            ViewBag.EquipoA = EquipoA;
            ViewBag.EquipoB = EquipoB;
            ViewBag.InequipoA = InequipoA;
            ViewBag.InequipoB = InequipoB;
            ViewBag.Aviso = Aviso;
            return View();
        }


        //-------------------------  RECIBE DEL TABLERO Y MANDA LOS EQUIPOS A A JUGAR, CON LA VISTA INDEX ------------
        [HttpPost]
        public ActionResult Index(string a)
        {
            Equiposas(a);
           
            return RedirectToAction("Index");
        }
        //-----------------------------------------------------------------------------------------------------------------
        //-------------------------  RECIBE DEL TABLERO OTHELLO EL GANADOR Y REDIRIJE A LA PANTALLA DEL DIAGRAMA ------------
        [HttpPost]
        public ActionResult Ganador(string ganador)
        {
            if (ganador == "empate") {
                int Index = 0;
                foreach (string e in Equipos)
                {
                    if (e == EquipoA)
                    {
                        Punteos[Index]= Punteos[Index]+ 1;
                    }
                    else if (e == EquipoB) {
                        Punteos[Index]= Punteos[Index]+1 ;
                    }
                    Index += 1;
                }
                Aviso = "Hay empate, tiene que haber un ganador";
                return RedirectToAction("Index");
            }
        //--------------- CUANDO NO HAY EMPATE ------------------
            else {
                Clasficar(ganador);
                InequipoA.Clear();
                InequipoB.Clear();
                int Index = 0;
                foreach (string e in Equipos)
                {
                    if (e == ganador)
                    {

                        Punteos[Index]= Punteos[Index]+3;
                    }
                    Index += 1;
                }
                Aviso = "";
            }
            

            return RedirectToAction("Tablero");
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
            ViewBag.Final1 = Final1;
            ViewBag.Final2 = Final2;
            ViewBag.Final = Final;

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
            for (int i = 0;i<Equipos.Count();i++)
            {

                Punteos.Add(0);
            }

        }


        //------------------------------------------ AUXILIA AL METODO HTTP POST CON LOS VALORES -----------------------------------
        public void Equiposas(string b) {
            if (b == "1") {
                EquipoA = E1;
                EquipoB = E2;
                Juego =b;
            } else if (b == "2") {
                EquipoA = E3;
                EquipoB = E4;
                Juego = b;
            }
            else if (b == "3") {
                EquipoA = E5;
                EquipoB = E6;
                Juego = b;
            } else if (b == "4")
            {
                EquipoA = E7;
                EquipoB = E8;
                Juego = b;
            }
            else if (b == "5")
            {
                EquipoA = E11;
                EquipoB = E12;
                Juego = b;
            }
            else if (b == "6")
            {
                EquipoA = E13;
                EquipoB = E14;
                Juego = b;
            }
            else if (b == "7")
            {
                EquipoA = E111;
                EquipoB = E112;
                Juego = b;
            }
            else if (b == "8")
            {
                EquipoA = E113;
                EquipoB = E114;
                Juego = b;
            }
            else if (b == "9")
            {
                EquipoA = E15;
                EquipoB = E16;
                Juego = b;
            }
            else if (b == "10")
            {
                EquipoA = E17;
                EquipoB = E18;
                Juego = b;
            }
            else if (b == "11")
            {
                EquipoA = E91;
                EquipoB = E92;
                Juego = b;
            }
            else if (b == "12")
            {
                EquipoA = E93;
                EquipoB = E94;
                Juego = b;
            }
            else if (b == "13")
            {
                EquipoA = E95;
                EquipoB = E96;
                Juego = b;
            }
            else if (b == "14")
            {
                EquipoA = E97;
                EquipoB = E98;
                Juego = b;
            }

            int cont = 0;
            foreach (string e in Equipos) {
                if (e == EquipoA)
                {
                    break;
                }
                else {
                    cont += 1;
                }
            }
            cont = cont * 3;
            InequipoA.Add(Integrantes[cont]);
            InequipoA.Add(Integrantes[cont+1]);
            InequipoA.Add(Integrantes[cont+2]);
            cont = 0;
            foreach (string e in Equipos)
            {
                if (e == EquipoB)
                {
                    break;
                }
                else
                {
                    cont += 1;
                }
            }
            cont = cont * 3;
            InequipoB.Add(Integrantes[cont]);
            InequipoB.Add(Integrantes[cont + 1]);
            InequipoB.Add(Integrantes[cont + 2]);
        }

        //-------------------------- ENCARGADO DE  ASIGNAR AL GANADOR A LA SIGUIENTE RONDA ------------------------------------------
        public void Clasficar(string b) {
            if (Juego == "1")
            {
                E11 = b;
            }
            else if (Juego == "2")
            {
                E12 = b;
            }
            else if (Juego == "3")
            {
                E13 = b;
            }
            else if (Juego == "4")
            {
                E14 = b;
            }
            else if (Juego == "5")
            {
                E111 = b;
            }
            else if (Juego == "6")
            {
                E112 = b;
            }
            else if (Juego == "7")
            {
                Final1 = b;
            }
            else if (Juego == "8")
            {
                Final2 = b;
            }
            else if (Juego == "9")
            {
                E113 = b;
            }
            else if (Juego == "10")
            {
                E114 = b;
            }
            else if (Juego == "11")
            {
                E15 = b;
            }
            else if (Juego == "12")
            {
                E16 = b;
            }
            else if(Juego == "13")
            {
                E17 = b;
            }
            else if (Juego  == "14")
            {
                E18 = b;
            }

           

        }
    }
}