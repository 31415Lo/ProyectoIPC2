using ProyectoIPC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class OthelloxtrController : Controller
    {

        static readonly List<Othelloxtreme> casillas = new List<Othelloxtreme>();
      
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
            Othelloxtreme lec = new Othelloxtreme();
            for (int i = 0; i <tamaño; i++)
            {

                lec.Index = 0;
                casillas.Add(lec);
            }

            for (int i = 0; i < color1.Count(); i++)
            {
                if (color1[i] == 1)
                {
                    col1 = "black";
                    colorj1.Add(col1);

                }
                else if (color1[i] == 2)
                {
                    col2 = "red";
                    colorj1.Add(col2);
                }
                else if (color1[i] == 3)
                {
                    col3 = "yellow";
                    colorj1.Add(col3);
                }
                else if (color1[i] == 4)
                {
                    col4 = "blue";
                    colorj1.Add(col4);
                }
                else if (color1[i] == 5)
                {
                    col5 = "orange";
                    colorj1.Add(col5);
                }
            }
            for (int i = 0; i < color2.Count(); i++)
            {
                if (color2[i] == 6)
                {
                    col6 = "white";
                    colorj2.Add(col6);
                }
                else if (color2[i] == 7)
                {
                    col7 = "green";
                    colorj2.Add(col7);
                }
                else if (color2[i] == 8)
                {
                    col8 = "violet";
                    colorj2.Add(col8);
                }
                else if (color2[i] == 9)
                {
                    col9 = "azure";
                    colorj2.Add(col9);
                }
                else if (color2[i] == 10)
                {
                    col10 = "grey";
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
            ViewData["Columnas"] = col;
            ViewData["filas"] = fil;
            ViewData["salto"] = salto;
            ViewBag.alfabeto = abecedario;
            //return View( casillas);
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
            List<string> coloraux1 = new List<string>(); //--- COLORES A VERIFICAR 
            List<string> coloraux2 = new List<string>(); //--- COLORES PARA COLOREAR

            int x1 = Int32.Parse(a);
            int Index = x1;

            if (turno == "j1")
            {
                coloraux1 = colorj2;  // SE VERIFICA LOS COLORES DEL JUGADOR INVITADO
                if (colorj1aux.Count()==0) { // COLOR J1AUX ES STATIC , POP 
                    colorj1aux = colorj1;
                }
                coloraux2 = colorj1aux; //SE ASINGA LA LISTA DEL COLOR PARA LAS NUEVAS CASIILAS
                turno = "j2"; // SE CAMBIA EL TURNO PARA EL JUGADOR DOS

            }
            else
            {
                coloraux1 = colorj1;  // SE VERIFICA LOS COLORES DEL USUARIO
                if (colorj2aux.Count() == 0)
                {
                    colorj2aux = colorj2;
                }
                coloraux2 = colorj2aux; //SE ASINGA LA LISTA DEL COLOR PARA LAS NUEVAS CASIILAS
                turno = "j1"; // SE CAMBIA EL TURNO PARA EL JUGADOR UNO
            }
            //------------------------------------------------------------------------------------------------------------------
            //---------------------------VERIFICAR QUE EL INDEX NO CONTENGA NINGUN COLOR YA EXISTENTE---------------------------


            // ----------   DEVUELVE SI SE SELECCIONA UN BOTON CON COLOR -----------------------------
            if (validarindex(Index))
            {
                ViewBag.ShowAlert = true;
            }
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------

            //------------------------------------------- RECOGE LAS FICHAS VALIDAS ------------------------------

            else
            {
                // ----------------------------- POSICION X1  (x1-1)----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 - 1, turno)) {
                        aux.Add(x1 - 1);
                        x1 -= 1;
                    }
                    else if (ValidaColores2(x1 - 1, turno)) {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else {
                        aux.Clear();
                        break;
                    }
                }

                // ----------------------------- POSICION X2  (x1-(fila+1))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 -(fil+1), turno))
                    {
                        aux.Add(x1 - (fil + 1));
                        x1 -= (fil + 1);
                    }
                    else if (ValidaColores2(x1 - (fil + 1), turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }
                // ----------------------------- POSICION X3  (x1-(fila))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 -fil, turno))
                    {
                        aux.Add(x1 -fil);
                        x1 -= fil;
                    }
                    else if (ValidaColores2(x1 - fil, turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }
                // ----------------------------- POSICION X4  (x1-(fila-1))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 - (fil - 1), turno))
                    {
                        aux.Add(x1 - (fil - 1));
                        x1 -= (fil - 1);
                    }
                    else if (ValidaColores2(x1 - (fil - 1), turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }
                // ----------------------------- POSICION X5  (x1+1))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 + 1, turno))
                    {
                        aux.Add(x1 + 1);
                        x1 +=1;
                    }
                    else if (ValidaColores2(x1 + 1, turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }
                // ----------------------------- POSICION X6  (x1+(fila+1)))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 + (fil+ 1), turno))
                    {
                        aux.Add(x1 + (fil + 1));
                        x1 += (fil + 1);
                    }
                    else if (ValidaColores2(x1 + (fil + 1), turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }
                // ----------------------------- POSICION X7  (x1+(fila)))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 + fil, turno))
                    {
                        aux.Add(x1 + fil);
                        x1 += fil;
                    }
                    else if (ValidaColores2(x1 + fil, turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }
                // ----------------------------- POSICION X8  (x1+(fila-1)))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 + (fil-1), turno))
                    {
                        aux.Add(x1 + (fil - 1));
                        x1 += (fil - 1);
                    }
                    else if (ValidaColores2(x1 + (fil - 1), turno))
                    {
                        foreach (int ele in aux)
                        {
                            general.Add(ele);
                        }
                        aux.Clear();
                        break;
                    }
                    else
                    {
                        aux.Clear();
                        break;
                    }
                }

            }
            //-------------------------------------------  TERMINA LA SECCION RECOGE LAS FICHAS VALIDAS ------------------------------
            //-------------------------------------------------------------------------------------------------------------------------


            if (general.Count > 0)
            {
                general.Add(Index);
                Colorear(general, turno);
            }
            else
            {
                //--- AGREGAR LA OPCION DE VALIDAR  LAS OPCION DE CAMBIAR EL TURNO.
                ViewData["Columnas"] = col;
                ViewData["filas"] = fil;
                ViewData["salto"] = salto;
                ViewBag.alfabeto = abecedario;
                return View("Index", casillas);
               
            }
            ViewData["Columnas"] = col;
            ViewData["filas"] = fil;
            ViewData["salto"] = salto;
            ViewBag.alfabeto = abecedario;
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
        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA VERFICIAR SI EL INDEX ES VALIDO CON EL COLOR ------------------
        public bool validarindex(int a) {

            foreach (string colorpre in colorj1) {
                if (casillas[a].Color == colorpre) {
                    return true;
                }
            }
            foreach (string colorpre in colorj2)
            {
                if (casillas[a].Color == colorpre)
                {
                    return true;
                }
            }

            return false;
        }

        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA VERFICIAR SI EL INDEX ES VALIDO CON EL COLOR ------------------
        public bool ValidaColores(int a,string turn) {

            if (turn == "j2")
            {
                foreach (string colorpre in colorj2)
                {
                    if (casillas[a].Color == colorpre)
                    {
                        return true;
                    }
                }

            }
            else {

                foreach (string colorpre in colorj1)
                {
                    if (casillas[a].Color == colorpre)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ValidaColores2(int a, string turn)
        {

            if (turn == "j2")
            {
                foreach (string colorpre in colorj1)
                {
                    if (casillas[a].Color == colorpre)
                    {
                        return true;
                    }
                }

            }
            else
            {

                foreach (string colorpre in colorj2)
                {
                    if (casillas[a].Color == colorpre)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------

        // -------------------------------  FUNCION ENCARGADA  DE COLOREAR LOS BOTONES NUEVOS ------------------
        public void Colorear(List<int> ind, string cl) {
            List<int> indices = new List<int>();
            indices = ind;
            /*string coloraplicar = "";

            if (cl == "j2")
            {
                coloraplicar = colorj1aux.First();
                foreach (int i in indices)
                {
                    casillas[i].Color = coloraplicar;
                }
                colorj1aux.Remove(coloraplicar);
            }
            else {
                coloraplicar = colorj2aux.First();
                foreach (int i in indices)
                {
                    casillas[i].Color = coloraplicar;
                }
                colorj2aux.Remove(coloraplicar);
            }*/
        }
        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------

        // ------------------------------- INICIAR PARTIDA // PARTIDA NORMARL- NO PERSONALIZADA  ------------------
        public ActionResult Iniciar1()
        {

            int x1 = ((fil / 2) * (col / 2)) - 1;
            int x2 = ((fil / 2) * (col / 2));

            string coloraplicar = colorj1.First();
            casillas[x1].Color =coloraplicar;
            Iniciar2(x2);
            ViewData["Columnas"] = col;
            ViewData["filas"] = fil;
            ViewData["salto"] = salto;
            ViewBag.alfabeto = abecedario;
            return View("Index", casillas);
        }
        public ActionResult Iniciar2(int a)
        {
            int x3 = ((fil / 2) * (col / 2)) + fil;
            int x4 = ((fil / 2) * (col / 2)) + fil + 1;
            if (a==x4) {
                string coloraplicar = colorj2.First();
                casillas[x4].Color = coloraplicar;
                ViewData["Columnas"] = col;
                ViewData["filas"] = fil;
                ViewData["salto"] = salto;
                ViewBag.alfabeto = abecedario;
                return View("Index", casillas);
            }
            else {
                string coloraplicar = colorj1.First();
                casillas[a].Color = coloraplicar;
                Iniciar3(x3);
                casillas[a].Color = coloraplicar;
                ViewData["Columnas"] = col;
                ViewData["filas"] = fil;
                ViewData["salto"] = salto;
                ViewBag.alfabeto = abecedario;
                return View("Index", casillas);
            }
        }
        public ActionResult Iniciar3(int b)
        {
            int x4 = ((fil / 2) * (col / 2)) + fil + 1;
            string coloraplicar = colorj2.First();
            casillas[b].Color = coloraplicar;
            Iniciar2(x4);
            ViewData["Columnas"] = col;
            ViewData["filas"] = fil;
            ViewData["salto"] = salto;
            ViewBag.alfabeto = abecedario;
            return View("Index", casillas);

        }

        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------










    }
}
