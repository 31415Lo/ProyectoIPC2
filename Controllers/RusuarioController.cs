using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Ajax.Utilities;
using ProyectoIPC2.Models;
using System.Configuration;

namespace ProyectoIPC2.Controllers
{
    public class RusuarioController : Controller
    {
        //readonly Var registro = new Rusuario();

       
        public ActionResult Index(string nombres, string apellidos, string usuario, string contraseña, string f_nac, string pais, string correo,string conf)
        {
            if (nombres!=null) {
                Registro(nombres, apellidos, usuario, contraseña, f_nac, pais, correo);
                return View();
            }
            return View();
        }
        public ActionResult Mensajero(string mensaje)
        {

            ViewBag.Mensaje = mensaje;

            return View();
        }

        private int id;
        private string nombres;
        private string apellidos;
        private string usuario;
        private string contraseña;
        private string f_nac;
        private string pais;
        private string correo;

        // GET: Rusuario

        // ------------------------------------------- METODOS GET Y SET ---------------------------------------------------
        public int getIdnombre()
        {
            return id;
        }
        public string getNombres()
        {
            return nombres;
        }
        public string getApellidos()
        {
            return apellidos;
        }
        public string getNom_usuario()
        {
            return usuario;
        }
        public string getContraseña()
        {
            return contraseña;
        }
        public string getfecha_nac()
        {
            return f_nac;
        }
        public string getPais()
        {
            return pais;
        }
        public string getCorreo()
        {
            return correo;
        }

        //---------------------------- SET-----------------------------

        public void setNombres(string nom)
        {
            nombres = nom;
        }

        public void setApellidos(string ap)
        {
            apellidos = ap;
        }

        public void setNom_usuario(string usu)
        {
            usuario = usu;
        }

        public void setContraseña(string contra)
        {
            contraseña = contra;
        }

        public void setfecha_nac(string nac)
        {
            f_nac = nac;
        }
        public void setPais(string p)
        {
            pais = p;
        }
        public void setCorreo(string co)
        {
            correo = co;
        }
        //-------------------------------------------------------REGISTRAR USUARIO------------------------------------------------


        [HttpPost]
        public void Registro(string nombres, string apellidos, string usuario, string contraseña, string f_nac, string pais, string correo)
        {
            try
            {
                
        string connectionString = @"Data Source=PILO-TUY; Initial Catalog =Project1; Integrated Security=True;";

                 SqlConnection sqlCon = new SqlConnection(connectionString);
                 sqlCon.Open();


             SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM Usuarios WHERE Nom_usuario='"+usuario+"'",sqlCon);
       
             SqlCommand read = new SqlCommand("SELECT* FROM Usuarios WHERE Nom_usuario='"+usuario+"'", sqlCon);
            SqlDataReader rd=read.ExecuteReader();
            if (rd.Read())
                {
                    Mensajero("Este usuario ya existe, Ingrese otro usuario");
                rd.Close();
                }else 
                {
                rd.Close();
                SqlDataAdapter sqlDa = new SqlDataAdapter("INSERT INTO Usuarios (Nombres,Apellidos,Nom_usuario,Contraseña,fecha_nac,Pais,Correo) VALUES ('" + nombres + "' , '" + apellidos + "' , '" + usuario + "', '" + contraseña + "', '" + f_nac + "', '" + pais + "', '" + correo + "')", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    sqlCon.Close();

                    Mensajero("Este usuario Creado con exito" );
                   
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

    }
}
        
        
        
 
    


