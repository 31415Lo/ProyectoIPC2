using ProyectoIPC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIPC2.Controllers
{
    public class ArchivosxmlController : Controller
    {
        static List<Lecturaxml> casillas = new List<Lecturaxml>();
        static bool negro = true;


        // GET: Archivosxml
        public ActionResult Index()
        {
            for (int i = 0; i < 64; i++)
            {
                Lecturaxml lec = new Lecturaxml();
                lec.Index = 0;
                casillas.Add(lec);

            }

            return View(casillas);

        }
        //--------------------------------- PARA CAMBIAR DE COLOR DE CADA CIRCULO ----------------------------------------
        public ActionResult Colores(string a)
        {
            List<int> general = new List<int>();
            List<int> aux = new List<int>();
            int x1 = Int32.Parse(a);
            string color1;
            string color2;
            if (negro == true)
            {
                color1 = "black";
                color2 = "white";
            }
            else
            {
                color2 = "black";
                color1 = "white";
            }

            int Index = Int32.Parse(a);

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

                // posicion X2
                x1 = Index;
                while (recorrer2("v1", "h1", x1))
                {
                    if (casillas[x1 - 9].Color == color2)
                    {
                        aux.Add(x1 - 9);
                        x1 -= 9;
                    }
                    else if (casillas[x1 - 9].Color == color1)
                    {
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
                // posicion x3
                x1 = Index;
                while (recorrer("h1", x1))
                {
                    if (casillas[x1 - 8].Color == color2)
                    {
                        aux.Add(x1 - 8);
                        x1 -= 8;
                    }
                    else if (casillas[x1 - 8].Color == color1)
                    {
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
                // posicion X4
                x1 = Index;
                while (recorrer2("h1", "v2", x1))
                {
                    if (casillas[x1 - 7].Color == color2)
                    {
                        aux.Add(x1 - 7);
                        x1 -= 7;
                    }
                    else if (casillas[x1 - 7].Color == color1)
                    {
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

                // posicion x5
                x1 = Index;
                while (recorrer("v2", x1))
                {
                    if (casillas[x1 + 1].Color == color2)
                    {
                        aux.Add(x1 + 1);
                        x1 += 1;
                    }
                    else if (casillas[x1 + 1].Color == color1)
                    {

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

                // posicion X6
                x1 = Index;
                while (recorrer2("v2", "h2", x1))
                {
                    if (casillas[x1 + 9].Color == color2)
                    {
                        aux.Add(x1 + 9);
                        x1 += 9;
                    }
                    else if (casillas[x1 + 9].Color == color1)
                    {
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
                // posicion x7
                x1 = Index;
                while (recorrer("h2", x1))
                {
                    if (casillas[x1 + 8].Color == color2)
                    {
                        aux.Add(x1 + 8);
                        x1 += 8;
                    }
                    else if (casillas[x1 + 8].Color == color1)
                    {
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
                // posicion X8
                x1 = Index;
                while (recorrer2("v1", "h2", x1))
                {
                    if (casillas[x1 + 7].Color == color2)
                    {
                        aux.Add(x1 + 7);
                        x1 += 7;
                    }
                    else if (casillas[x1 + 7].Color == color1)
                    {
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
                Negro1(general, color1);
            }
            else
            {
                return View("Index", casillas);
            }

            return View("Index", casillas);

        }
        // ----------------------------------------------- SE HACEN EL CAMBIO DE COLOR -------------
        public ActionResult Negro1(List<int> ll, string color)
        {
            if (ll.Count() > 0)
            {
                casillas[ll[0]].Color = color;
                ll.RemoveAt(0);
                if (ll.Count > 0)
                {
                    Negro2(ll, color);
                }
            }

            return View("Index", casillas);
        }
        public ActionResult Negro2(List<int> lll, string color)
        {
            if (lll.Count > 0)
            {
                casillas[lll[0]].Color = color;
                lll.RemoveAt(0);
                if (lll.Count() > 0)
                {
                    Negro2(lll, color);
                }
            }
            return View("Index", casillas);
        }



        // --------------------------------------- INICIAR TABLERO ------------------------------------------------


        public ActionResult Limpiar()
        {
            for (int i = 0; i < 64; i++)
            {
                casillas[i].Color =null;
            }
            return RedirectToAction("Index"); ;
        }


        //-------------------    CARGAR FICHAS DE INICIO   ---------------------------------------------

        public ActionResult Colores2()
        {
            
            int Index = 27;
            casillas[Index].Color = "white";
            Colores3(28);
            return View("Index", casillas);
        }
        public ActionResult Colores3(int a)
        {
            if (a == 36)
            {
                casillas[a].Color = "white";
                return View("Index", casillas);

            }
            else
            {
                int Index = a;
                casillas[Index].Color = "black";
                Colores4(35);
                return View("Index", casillas);
            }

        }
        public ActionResult Colores4(int b)
        {
            int Index = 35;
            casillas[Index].Color = "black";
            Colores3(36);
            return View("Index", casillas);
        }


        //------------------------------------------------------------- funcion para recorrer fichas -------------------

        public bool recorrer(string a, int b)
        {
            //listas donde se encuentran las fronteras

            if (a == "v1")
            {
                List<int> lista1 = new List<int>();
                lista1.Add(0);
                lista1.Add(8);
                lista1.Add(16);
                lista1.Add(24);
                lista1.Add(32);
                lista1.Add(40);
                lista1.Add(48);
                lista1.Add(56);
                for (int i = 0; i < 8; i++)
                {
                    if (b == lista1[i])
                    {
                        return false;
                    }
                }
                return true;

            }
            else if (a == "v2")
            {
                List<int> lista2 = new List<int>();
                lista2.Add(7);
                lista2.Add(15);
                lista2.Add(23);
                lista2.Add(31);
                lista2.Add(39);
                lista2.Add(47);
                lista2.Add(55);
                lista2.Add(63);
                for (int i = 0; i < 8; i++)
                {
                    if (b == lista2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (a == "h1")
            {
                List<int> lista3 = new List<int>();
                lista3.Add(0);
                lista3.Add(1);
                lista3.Add(2);
                lista3.Add(3);
                lista3.Add(4);
                lista3.Add(5);
                lista3.Add(6);
                lista3.Add(7);
                for (int i = 0; i < 8; i++)
                {
                    if (b == lista3[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                List<int> lista4 = new List<int>();
                lista4.Add(56);
                lista4.Add(57);
                lista4.Add(58);
                lista4.Add(59);
                lista4.Add(60);
                lista4.Add(61);
                lista4.Add(62);
                lista4.Add(63);
                for (int i = 0; i < 8; i++)
                {
                    if (b == lista4[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        //-------------------------------------------------------------
        public bool recorrer2(string a, string c, int b)
        {
            //listas donde se encuentran las fronteras
            if (a == "v1" && c == "h1")
            {
                List<int> lista1 = new List<int>();
                lista1.Add(0);
                lista1.Add(8);
                lista1.Add(16);
                lista1.Add(24);
                lista1.Add(32);
                lista1.Add(40);
                lista1.Add(48);
                lista1.Add(56);
                lista1.Add(1);
                lista1.Add(2);
                lista1.Add(3);
                lista1.Add(4);
                lista1.Add(5);
                lista1.Add(6);
                lista1.Add(7);
                for (int i = 0; i < 15; i++)
                {
                    if (b == lista1[i])
                    {
                        return false;
                    }
                }
                return true;

            }
            else if (a == "h1" && c == "v2")
            {
                List<int> lista2 = new List<int>();
                lista2.Add(7);
                lista2.Add(15);
                lista2.Add(23);
                lista2.Add(31);
                lista2.Add(39);
                lista2.Add(47);
                lista2.Add(55);
                lista2.Add(63);
                lista2.Add(0);
                lista2.Add(1);
                lista2.Add(2);
                lista2.Add(3);
                lista2.Add(4);
                lista2.Add(5);
                lista2.Add(6);
                for (int i = 0; i < 15; i++)
                {
                    if (b == lista2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (a == "v2" && c == "h2")
            {
                List<int> lista3 = new List<int>();
                lista3.Add(7);
                lista3.Add(15);
                lista3.Add(23);
                lista3.Add(31);
                lista3.Add(39);
                lista3.Add(47);
                lista3.Add(55);
                lista3.Add(63);
                lista3.Add(56);
                lista3.Add(57);
                lista3.Add(58);
                lista3.Add(59);
                lista3.Add(60);
                lista3.Add(61);
                lista3.Add(62);
                for (int i = 0; i < 15; i++)
                {
                    if (b == lista3[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (a == "v1" && c == "h2")
            {
                List<int> lista4 = new List<int>();
                lista4.Add(56);
                lista4.Add(57);
                lista4.Add(58);
                lista4.Add(59);
                lista4.Add(60);
                lista4.Add(61);
                lista4.Add(62);
                lista4.Add(63);
                lista4.Add(0);
                lista4.Add(8);
                lista4.Add(16);
                lista4.Add(24);
                lista4.Add(32);
                lista4.Add(40);
                lista4.Add(48);
                for (int i = 0; i < 15; i++)
                {
                    if (b == lista4[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }






        [HttpPost]
        public ActionResult Cargarxml(HttpPostedFileBase file)
        {
            List<int> listado = new List<int>();
            List<String> colores = new List<String>();
           
            string color="null";
            if (file != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file.InputStream);
                foreach (XmlNode node in doc.SelectNodes("/tablero/ficha"))
                {
                    int ficha = Valor(node["columna"].InnerText, node["fila"].InnerText);
                    if (ficha < 100)
                    {
                        listado.Add(ficha);
                        if (node["color"].InnerText == "negro")
                        {
                            color = "black";
                        }
                        else
                        {
                            color = "white";
                        }
                        colores.Add(color);
                    }
                    else {
                        ViewBag.Carga = "Archivo no valido";
                        //return RedirectToAction("Index");

                    }
                }
                if (Validar(listado))
                {
                    Color1(listado, colores);
                }
                else {
                   ViewBag.Carga ="Archivo no valido"; 
                    //return RedirectToAction("Index");
                }

               

            }
                    return RedirectToAction("Index"); 
                
        }
        //--------------------------------------- METODO QUE DEVUELVE LA VISTA DEL ARCHIVO CARGADO ------------------------
        public ActionResult Color1(List<int> ll, List<string> cc)
        {
            if (ll.Count() > 0)
            {
                casillas[ll[0]].Color =cc[0];
                ll.RemoveAt(0);
                cc.RemoveAt(0);
                if (ll.Count > 0)
                {
                    Color2(ll, cc);
                }
            }

            return View("Index", casillas);
        }
        public ActionResult Color2(List<int> lll, List<string> ccc)
        {
            if (lll.Count > 0)
            {
                casillas[lll[0]].Color = ccc[0];
                lll.RemoveAt(0);
                ccc.RemoveAt(0);
                if (lll.Count() > 0)
                {
                    Color1(lll, ccc);
                }
            }
            return View("Index", casillas);
        }
        //--------------------------------------- METODO QUE DEVUELVE LA VISTA DEL ARCHIVO CARGADO ------------------------
        public int Valor(string columna, string fila) {
            int val=100;
            if (columna == "A") {val = 0;}
            else if (columna == "B") { val = 1; }
            else if (columna == "C") { val = 2; }
            else if (columna == "D") { val = 3; }
            else if (columna == "E") { val = 4; }
            else if (columna == "F") { val = 5; }
            else if (columna == "G") { val = 6; }
            else if (columna == "H") { val = 7; }
            if (fila == "1") { val = val+0; }
            else if (fila == "2") { val = val + 8; }
            else if (fila == "3") { val = val + 16; }
            else if (fila == "4") { val = val + 24; }
            else if (fila == "5") { val = val + 32; }
            else if (fila == "6") { val = val + 40; }
            else if (fila == "7") { val = val + 48; }
            else if (fila == "8") { val = val + 56; }
            return val;
        }
        // ---------------------------------  METODO PARA VALIDAR ARCHIVOS CARGADOS --------------------------

        public bool Validar(List<int> ll) {
           
            List<int> aux= new List<int>();
            aux.Clear();

            foreach (int a in ll) {
                aux.Add(a);
            }

            for (int i=0;i<ll.Count;i++) {

                for (int j = 0; j < aux.Count; j++)
                {
                    if (i == j)
                    {
                    }
                    else {
                        if (ll[i] == aux[j]) {
                            return false;
                        }     
                    }
                }
            }

            for (int i = 0; i < ll.Count; i++)
            {
                int au = ll[i];
                for (int j = 0; j < aux.Count; j++)
                {
                    if (i == j)
                    {
                    }
                    else
                    {
                        if (au - 9 == aux[j] || au - 8 == aux[j] || au - 7 == aux[j] || au - 1 == aux[j] || au + 1 == aux[j] || au + 7 == aux[j] || au+8 == aux[j] || au+9 == aux[j])
                        {

                        }
                        else {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


    }
}