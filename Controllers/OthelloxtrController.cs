﻿using ProyectoIPC2.Models;
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
        static List<string> Juego = new List<string>(); //-------------------- PRUEBA CON ESTA LISTA PARA COLOREAR LAS FICHAS
        static List<int> front = new List<int>();
        static List<string> abecedario = new List<string>();
        static List<string> colorj1 = new List<string>(); //-- CORRESPONDE  A LOS COLORES DEL USUARIO O JUGADOR 1 "j1"
        static List<string> colorj2 = new List<string>();//-- CORRESPONDE  A LOS COLORES DEL JUGADOR INVITADO O JUGADOR 2  "j2"
        static List<string> Coj1aux = new List<string>(); //-- CORRESPONDE  A LOS COLORES DEL USUARIO O JUGADOR 1 "j1aux" VACIADO Y REASIGNADO
        static List<string> Coj2aux = new List<string>(); //-- CORRESPONDE  A LOS COLORES DEL USUARIO O JUGADOR 1 "j1"  VACIADO Y REASIGNADO
        static string turno = "";    //-  PARA VALIDAR EL TURNO
        static string Ganador = "";
        static string Invitado = "";
        static int Mov1 = 0;
        static int Mov2 = 0;
        static int punteo1 = 0;
        static int punteo2 = 0;
        static string ModalidadColores = "";   // ------- PUEDE SER DE APERTURA PERSONALIZADA O APERTURA NORMAL 
        static string ModalidadPartida = "";  // -------- PUEDE SER DEL MODO INVERSO O DEL MODO NORMAL 
        static bool appvalidado = false;

        /*
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
        */

        // GET: Othelloxtreme
        public ActionResult Index()
        {

            ViewData["Columnas"] = col;
            ViewData["filas"] = fil;
            ViewData["salto"] = salto;
            ViewBag.alfabeto = abecedario;
            ViewBag.Juego = Juego;
            ViewBag.Color1 = colorj1;
            ViewBag.Color2 = colorj2;
            ViewBag.Turno = turno;
            ViewBag.Ganador = Ganador;
            ViewBag.Invitado = Invitado;
            ViewBag.Mov1 = Mov1;
            ViewBag.Mov2 = Mov2;
            ViewBag.Punteo1 = punteo1;
            ViewBag.Punteo2 = punteo2;
            return View(casillas);
        }

        [HttpPost]
        public ActionResult Index(IList<int> color1, IList<int> color2, int columnas, int filas, string modalidad, string opcion, string nombre)
        {

            col = columnas;
            fil = filas;
            tamaño = col * filas;
            ModalidadColores = modalidad; // --- MODALIDAD DE PERSONALIZACION DE COLORES 
            ModalidadPartida = opcion; // ----- MODALIDAD INVERSO O NORMAL 
            Invitado = nombre;
            //Othelloxtreme lec = new Othelloxtreme();
            for (int i = 0; i < tamaño; i++)
            {

                string c = null;
                Juego.Add(c);
                // lec.Index = 0;
                //casillas.Add(lec);
            }

            for (int i = 0; i < color1.Count(); i++)
            {
                if (color1[i] == 1)
                {
                    colorj1.Add("black");

                }
                else if (color1[i] == 2)
                {
                    colorj1.Add("red");
                }
                else if (color1[i] == 3)
                {
                    colorj1.Add("yellow");
                }
                else if (color1[i] == 4)
                {
                    colorj1.Add("blue");
                }
                else if (color1[i] == 5)
                {
                    colorj1.Add("orange");
                }
            }
            for (int i = 0; i < color2.Count(); i++)
            {
                if (color2[i] == 6)
                {
                    colorj2.Add("white");
                }
                else if (color2[i] == 7)
                {
                    colorj2.Add("green");
                }
                else if (color2[i] == 8)
                {
                    colorj2.Add("violet");
                }
                else if (color2[i] == 9)
                {
                    colorj2.Add("azure");
                }
                else if (color2[i] == 10)
                {
                    colorj2.Add("grey");
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
            Frontera();


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

            if (appvalidado==false) {
                int aux = Int32.Parse(a);
                APersonalizadaTablero(aux);
            }
            else { 
            List<int> general = new List<int>();
            List<int> aux = new List<int>();
            List<string> coloraux1 = new List<string>(); //--- COLORES A VERIFICAR 
            List<string> coloraux2 = new List<string>(); //--- COLORES PARA COLOREAR

            int x1 = Int32.Parse(a);
            int Index = x1;


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

                if (turno == "j1")
                {

                    turno = "j2"; // SE CAMBIA EL TURNO PARA EL JUGADOR DOS 
                    Mov1 += 1;

                }
                else
                {

                    turno = "j1"; // SE CAMBIA EL TURNO PARA EL JUGADOR UNO
                    Mov2 += 1;
                }


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

                // ----------------------------- POSICION X2  (x1-(columna+1))----------------------------------
                x1 = Index;
                while (Validarfrontera(x1))
                {
                    if (ValidaColores(x1 - (col + 1), turno))
                    {
                        aux.Add(x1 - (col + 1));
                        x1 -= (col + 1);
                    }
                    else if (ValidaColores2(x1 - (col + 1), turno))
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
                    if (ValidaColores(x1 - col, turno))
                    {
                        aux.Add(x1 - col);
                        x1 -= col;
                    }
                    else if (ValidaColores2(x1 - col, turno))
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
                    if (ValidaColores(x1 - (col - 1), turno))
                    {
                        aux.Add(x1 - (col - 1));
                        x1 -= (col - 1);
                    }
                    else if (ValidaColores2(x1 - (col - 1), turno))
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
                        x1 += 1;
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
                    if (ValidaColores(x1 + (col + 1), turno))
                    {
                        aux.Add(x1 + (col + 1));
                        x1 += (col + 1);
                    }
                    else if (ValidaColores2(x1 + (col + 1), turno))
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
                    if (ValidaColores(x1 + col, turno))
                    {
                        aux.Add(x1 + col);
                        x1 += col;
                    }
                    else if (ValidaColores2(x1 + col, turno))
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
                    if (ValidaColores(x1 + (col - 1), turno))
                    {
                        aux.Add(x1 + (col - 1));
                        x1 += (col - 1);
                    }
                    else if (ValidaColores2(x1 + (col - 1), turno))
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
                Modpartida();
                return RedirectToAction("Index");

            }
                Modpartida();
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");

        }

        //--------------------------------------------------------------------------------------------------------------
        //---------------------------------- LISTA ENCARGADA DE RECORRER LAS FRONTERAS DEL TABLERO ---------------------
        public void Frontera()
        {

            //------- PRIMERA FRONTERA, FILA SUPERIOR
            for (int i = 0; i < col; i++) {
                front.Add(i);
            }
            // ------------ SEGUNDA FRONTERA, FRONTERA INFERIOR 
            for (int i = (tamaño - 1); i > (tamaño - (col + 1)); i--)
            {
                front.Add(i);
            }
            // ------------ TERCERA FRONTERA, FRONTERA IZQUIERDA
            for (int i = col; i < (tamaño - col); i += col)
            {
                front.Add(i);
            }
            // ------------ CUARTA FRONTERA, FRONTERA DERECHA
            for (int i = (col - 1); i < (tamaño - col); i += (col))
            {
                front.Add(i);
            }
        }
        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA DE VALIDAR LAS FRONTERAS   -------------------------------
        public bool Validarfrontera(int a) {

            foreach (int i in front) {
                if (a == i) {
                    return false;
                }
            }
            return true;
        }
        //--------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA VERFICIAR SI EL INDEX ES VALIDO CON EL COLOR ------------------
        public bool validarindex(int a) {

            foreach (string colorpre in colorj1) {
                if (Juego[a] == colorpre) {
                    return true;
                }
            }
            foreach (string colorpre in colorj2)
            {
                if (Juego[a] == colorpre)
                {
                    return true;
                }
            }

            return false;
        }

        //--------------------------------------------------------------------------------------------------------------
        // -------------------------------  FUNCION ENCARGADA VERFICIAR SI EL INDEX ES VALIDO CON EL COLOR ------------------
        public bool ValidaColores(int a, string turn) {

            if (turn == "j2")
            {
                foreach (string colorpre in colorj2)
                {
                    if (Juego[a] == colorpre)
                    {
                        return true;
                    }
                }

            }
            else {

                foreach (string colorpre in colorj1)
                {
                    if (Juego[a] == colorpre)
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
                    if (Juego[a] == colorpre)
                    {
                        return true;
                    }
                }

            }
            else
            {

                foreach (string colorpre in colorj2)
                {
                    if (Juego[a] == colorpre)
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
        public void Colorear(List<int> ind, string cl)
        {
            List<int> indices = new List<int>();
            indices = ind;
            string coloraplicar = "";

            if (cl == "j2")
            {
                if (Coj1aux.Count() == 0)
                {
                    llenarcolores("j1");


                }
                coloraplicar = Coj1aux[0];
                foreach (int i in indices)
                {
                    Juego[i] = coloraplicar;
                }
                Coj1aux.RemoveAt(0);
            }
            else
            {
                if (Coj2aux.Count() == 0)
                {
                    llenarcolores("j2");
                }
                coloraplicar = Coj2aux[0];
                foreach (int i in indices)
                {
                    Juego[i] = coloraplicar;
                }
                Coj2aux.RemoveAt(0);


            }
        }
        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------

        // ------------------------------- INICIAR PARTIDA // PARTIDA NORMARL- NO PERSONALIZADA  -----------------------
        //--------------------------------------------------------------------------------------------------------------
        public ActionResult Iniciar1()
        {

            if (ModalidadColores == "personalizada") {
                llenarcolores("j1");
                llenarcolores("j2");
                Appersonalizada();
                turno = "j1";

            } else {
                appvalidado = true;
                int x1 = ((fil / 2) * (col)) - (col / 2) - 1;
                int x2 = ((fil / 2) * (col)) - (col / 2);
                int x3 = x1 + col;
                int x4 = x2 + col;
                llenarcolores("j1");
                string coloraplicar = Coj1aux[0];
                Juego[x1] = coloraplicar;
                Coj1aux.RemoveAt(0);

                if (Coj1aux.Count() == 0)
                {
                    llenarcolores("j1");
                }
                coloraplicar = Coj1aux[0];
                Juego[x4] = coloraplicar;
                Coj1aux.RemoveAt(0);

                llenarcolores("j2");
                coloraplicar = Coj2aux[0];
                Juego[x2] = coloraplicar;
                Coj2aux.RemoveAt(0);

                if (Coj2aux.Count() == 0)
                {
                    llenarcolores("j2");
                }
                coloraplicar = Coj2aux[0];
                Juego[x3] = coloraplicar;
                Coj2aux.RemoveAt(0);
                turno = "j1";
            }
            

            return RedirectToAction("Index");
        }

        //--------------------------------------------------------------------------------------------------------------
        //-------------------------------------------LLENADO DE COLORES PARA CUALQUIER  MODALIDAD ---------------------------------------------


        public void llenarcolores(string a) {

            if (a == "j1")
            {
                for (int i = 0; i < colorj1.Count(); i++)
                {
                    Coj1aux.Add(colorj1[i]);
                }
            }
            else {
                for (int i = 0; i < colorj2.Count(); i++)
                {
                    Coj2aux.Add(colorj2[i]);
                }

            }



        }


        //------------------------------------------ SE DEFINE EL RETO INVERSO----------------------------------
        public void Modpartida() {
            int cantida1 = 0;
            int cantidad2 = 0;

            for (int i = 0; i < Juego.Count(); i++) {
                foreach (string c in colorj1) {
                    if (Juego[i] == c) {
                        cantida1 += 1;
                    }
                }
                foreach (string c in colorj2)
                {
                    if (Juego[i] == c)
                    {
                        cantidad2 += 1;
                    }
                }

            }


            punteo1 = cantida1;
            punteo2 = cantidad2;
            if (ModalidadPartida == "inverso") {
                if (cantida1 > cantidad2)
                {
                    Ganador = Invitado;
                }
                else if (cantidad2 > cantida1)
                {
                    Ganador = "Usuario";
                }
                else {
                    Ganador = " Empate";
                }
            }
            else {
                if (cantida1 > cantidad2)
                {

                    Ganador = "Usuario";
                }
                else if (cantidad2 > cantida1)
                {
                    Ganador = Invitado;
                }
                else
                {
                    Ganador = " Empate";
                }

            }


        }


        public void Appersonalizada(){
            int x1 = ((fil / 2) * (col)) - (col / 2) - 1;
            int x2 = ((fil / 2) * (col)) - (col / 2);
            int x3 = x1 + col;
            int x4 = x2 + col;
            Juego[x1]= "cafe";
            Juego[x2] = "cafe";
            Juego[x3] = "cafe";
            Juego[x4] = "cafe";
            turno = "j1";
        }

        public void APersonalizadaTablero(int a) {
            int x1 = ((fil / 2) * (col)) - (col / 2) - 1;
            int x2 = ((fil / 2) * (col)) - (col / 2);
            int x3 = x1 + col;
            int x4 = x2 + col;
            string coloraplicar = "";

            if (a == x1 || a == x2 || a == x3 || a == x4)
            {
                if (turno == "j1")
                {
                    if (Juego[a] == "cafe")
                    {
                        if (Coj1aux.Count() == 0)
                        {
                            llenarcolores("j1");
                        }
                        coloraplicar = Coj1aux[0];
                        Juego[a] = coloraplicar;
                        Coj1aux.RemoveAt(0);
                        turno = "j2";
                        Ganador = "";
                    }
                    else {
                        turno = "j1";
                        Ganador = "";
                    }

                }
                else
                {
                    if (Juego[a] == "cafe")
                    {
                        if (Coj2aux.Count() == 0)
                        {
                            llenarcolores("j2");
                        }
                        coloraplicar = Coj2aux[0];
                        Juego[a] = coloraplicar;
                        Coj2aux.RemoveAt(0);
                        turno = "j1";
                        Ganador = "";
                    }
                    else {
                        turno = "j2";
                        Ganador = "";
                    }
                }
            }
            else
            {
                Ganador = "MOVIMIENTO NO VALIDO";
            }

            // validar si se cumpliero las 4 casillas iniciales 

            if (Juego[x1] != "cafe" && Juego[x2] != "cafe" && Juego[x3] != "cafe" && Juego[x4] != "cafe") {
                appvalidado = true;
            }
            else {
                appvalidado = false;
            }


        }

        public ActionResult Limpiar() {

            for (int i=0; i<Juego.Count();i++) {

                Juego[i] = null;
            
            }



            return RedirectToAction("Index");
        }




    }
}
