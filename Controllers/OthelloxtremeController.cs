using ProyectoIPC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class OthelloxtremeController : Controller
    {

        static List<Othelloxtreme> casillas = new List<Othelloxtreme>();
        static Othelloxtreme tablero = new Models.Othelloxtreme();
        static bool negro = true;
        static int mov1 = 0;
        static int mov2 = 0;
        //-------------------- VARIABLES AGREGADOS RECIENTEMETE---------

        static int col = 0;
        static int fil = 0;
        static int tamaño = 0;
        static int salto = 0;
        static List<string> abecedario = new List<string>(); 
        static List<string> colorj1 = new List<string>(); //-- CORRESPONDE  A LOS COLORES DEL USUARIO O JUGADOR 1 "j1"
        static List<string> colorj2 = new List<string>();//-- CORRESPONDE  A LOS COLORES DEL JUGADOR INVITADO O JUGADOR 2  "j2"
        static List<string> colorj1aux = new List<string>(); //-- CORRESPONDE  A LOS COLORES DEL USUARIO O JUGADOR 1 "j1aux" VACIADO Y REASIGNADO
        static List<string> colorj2aux = new List<string>(); //-- CORRESPONDE  A LOS COLORES DEL USUARIO O JUGADOR 1 "j1"  VACIADO Y REASIGNADO
        static String turno = "j1";    //-  PARA VALIDAR EL TURNO

        static string col1 = ""; //"black"
        static string col2 = "";// "red"
        static string col3 = "";// "yellow"
        static string col4 = "";// "blue"
        static string col5 = "";// "orange"
        static string col6 = "";// "white"
        static string col7 = "";// "green"
        static string col8 = "";// "violet"
        static string col9 = "";// "azure"
        static string col10 = "";// "grey"


        // GET: Othelloxtreme
        public ActionResult Index()
        {
            Othelloxtreme lec = new Othelloxtreme();
            for (int i = 0; i < tamaño; i++)
            {

                lec.Index = 0;
                casillas.Add(lec);
            }
            lec.Columna = col;
            lec.Fila = fil;
            ViewData["Columnas"] = col;
            ViewData["filas"] = fil;
            ViewData["salto"] = salto;
            ViewBag.alfabeto = abecedario;
            return View(casillas);
        }

        [HttpPost]
        public ActionResult Index(IList<int> color1, IList<int> color2, int columnas, int filas)
        {
            col = columnas;
            fil = filas;
            tamaño = col * filas;
            for (int i = 0; i < color1.Count(); i++)
            {
                if (color1[i] == 1)
                {
                    col1 = "negro";
                    colorj1.Add(col1);

                }
                else if (color1[i] == 2)
                {
                    col2 = "rojo";
                    colorj1.Add(col2);
                }
                else if (color1[i] == 3)
                {
                    col3 = "amarillo";
                    colorj1.Add(col3);
                }
                else if (color1[i] == 4)
                {
                    col4 = "azul";
                    colorj1.Add(col4);
                }
                else if (color1[i] == 5)
                {
                    col5 = "anaranjado";
                    colorj1.Add(col5);
                }
            }
            for (int i = 0; i < color2.Count(); i++)
            {
                if (color2[i] == 6)
                {
                    col6 = "blanco";
                    colorj2.Add(col6);
                }
                else if (color2[i] == 7)
                {
                    col7 = "verde";
                    colorj2.Add(col7);
                }
                else if (color2[i] == 8)
                {
                    col8 = "violeta";
                    colorj2.Add(col8);
                }
                else if (color2[i] == 9)
                {
                    col9 = "celeste";
                    colorj2.Add(col9);
                }
                else if (color2[i] == 10)
                {
                    col10 = "gris";
                    colorj2.Add(col10);
                }
            }

            //return View(tablero);
            if (col == 20)
            {
                salto = 10;
            }
            else if (col == 18) {
                salto = 9;

            }
            else if (col == 16)
            {
                salto = 8;

            }
            else if (col == 14)
            {
                salto = 7;

            }
            else if (col == 12)
            {
                salto = 6;

            }
            else if (col == 10)
            {
                salto = 5;

            }
            else if (col == 8)
            {
                salto = 4;
            }
            else if (col == 6)
            {
                salto = 3;

            }
            llenar();
            return RedirectToAction("Index");
        }

        public void llenar() {
            abecedario.Add("A");
            abecedario.Add("B");
            abecedario.Add("C");
            abecedario.Add("D");
            abecedario.Add("E");
            abecedario.Add("F");
            abecedario.Add("G");
            abecedario.Add("H");
            abecedario.Add("I");
            abecedario.Add("J");
            abecedario.Add("K");
            abecedario.Add("L");
            abecedario.Add("M");
            abecedario.Add("N");
            abecedario.Add("O");
            abecedario.Add("P");
            abecedario.Add("Q");
            abecedario.Add("R");
            abecedario.Add("S");
            abecedario.Add("T");
            abecedario.Add("U");
            abecedario.Add("V");
        }


        //---------------------------------------------------  INICIACION DEL TABLERO ------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        public ActionResult Jugar(string a)
        {
            List<int> general = new List<int>();
            List<int> aux = new List<int>();
            List<string> coloraux1 = new List<string>(); //--- COLOR A VERIFICAR 
            List<string> coloraux2 = new List<string>(); //--- COLORES A VERIFICAR 

            int x1 = Int32.Parse(a);
            int Index = x1;

            if (turno == "j1")
            {
                coloraux1
            }
            else
            {
                color2 = "black";
                color1 = "white";
                mov2 += 1;
                turno = "Usuario";
            }

         

            // ----------   DEVUELVE SI SE SELECCIONA UN BOTON CON COLOR -----------------------------
            if (casillas[Index].Color == "black" || casillas[Index].Color == "white")
            {
                ViewBag.ShowAlert = true;
            }
            //------------------------------------------- CONTROLA LOS BOTONES NEGROS ------------------------------
            else
            {
                // posicion x1
                while (recorrer("v1", x1))
                {
                    if (casillas[x1 - 1].Color == color2)
                    {
                        aux.Add(x1 - 1);
                        x1 -= 1;
                    }
                    else if (casillas[x1 - 1].Color == color1)
                    {
                        //aux.Add(Index);  agregarlo al final 
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }

              
              
            }
            if (general.Count > 0)
            {
                general.Add(Index);
                if (negro)
                {
                    negro = false;
                }
                else
                {
                    negro = true;
                }
                // ViewBag.Movimientos =mov1;
                //ViewBag.Movimientos1 = mov2;
                //  Negro1(general, color1);
            }
            else
            {
                return View("Index", casillas);
            }

            return View("Index", casillas);

        }

        //--------------------------------------------------------------------------------------------------------------
        //---------------------------------- LISTA ENCARGADA DE RECORRER LAS FRONTERAS DEL TABLERO ---------------------
        public List<int> Frontera()
        {
            List<int> frontera = new List<int>();
            //------- PRIMERA FRONTERA, FILA SUPERIOR
            for (int i=0;i<fil;i++) {
                frontera.Add(i);
            }
            // ------------ SEGUNDA FRONTERA, FRONTERA INFERIOR 
            for (int i = (tamaño-1); i>(tamaño-(fil+1)); i--)
            {
                frontera.Add(i);
            }
            // ------------ TERCERA FRONTERA, FRONTERA IZQUIERDA
            for (int i =fil; i <(tamaño-fil); i++)
            {
                frontera.Add(i);
            }
            // ------------ CUARTA FRONTERA, FRONTERA DERECHA
            for (int i = fil; i < (tamaño - fil); i++)
            {
                frontera.Add(i);
            }
            return frontera;
        }
        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA DE VALIDAR LAS FRONTERAS   -------------------------------
        public bool Validarfrontera(int a) {
            List<int> frontera = new List<int>();
            frontera = Frontera();
            foreach (int i in frontera) {
                if (a==i) {
                    return false;
                }
            }
            return true;
        }
        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA   DE REASIGNAR LOS LISTADOS DE COLORES  ------------------
        public void llenarlista(string a) {

            if (a == "j1")
            {
                colorj1aux = colorj1;
            }
            else {
                colorj2aux = colorj2;
            }
        }


    }
}
