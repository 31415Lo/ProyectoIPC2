using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIPC2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string usuario, string pwd )
        {
            if (usuario != null )
            {
                Logueo(usuario,pwd);
                return View();
            }
            return View();
        }

        public ActionResult Correccion(string mensaje)
        {

            ViewBag.Correccion= mensaje;

            return View();
        }

        [HttpPost]
        public ActionResult Menujuego()
        {
            return View();
        }





        //----------------------------------------------- LOGIN DE USUARIO-----------------------------------------------------
        
        public void Logueo( string usuario, string contraseña )
        {
            try
            {

                string connectionString = @"Data Source=PILO-TUY; Initial Catalog =Project1; Integrated Security=True;";

                SqlConnection sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();


                //SqlDataAdapter sda = new SqlDataAdapter("SELECT Nom_usuario, pass FROM Usuarios WHERE Nom_usuario='" + usuario + "'", sqlCon);

                SqlCommand read = new SqlCommand("SELECT Nom_usuario,Contraseña FROM Usuarios WHERE Nom_usuario='" +usuario+ "' AND Contraseña='" +contraseña+ "'", sqlCon);
                SqlDataReader rd = read.ExecuteReader();
                if (rd.Read())
                {
                    rd.Close();
                    sqlCon.Close();
                  
                }
                else
                {
                 Correccion("Usuario / Contraseña no coincide");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }








    }
}