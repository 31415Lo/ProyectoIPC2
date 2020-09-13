using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Ajax.Utilities;

namespace ProyectoIPC2.Models
{
    public class Rusuario
    {






        /*
        static String connection = @"Data Source=PILO-TUY;Initial Catalog=Project1;Integrated Security=true";
        SqlConnection connect = new SqlConnection(connection);// aqui donde se guarda la conexion a la base de datos

        private int id;
        private string nombres;
        private string apellidos;
        private string usuario;
        private string contraseña;
        private string f_nac;
        private string pais;
        private string correo;
        private SqlCommand comand;
        private SqlDataReader sqlread;
        private string obtener;

        //-------------------------- METODO PARA CONECTAR CON LA BASE DE DATOS----------------------------------
        public void Connectdb()
        {
            if (connect.State != ConnectionState.Open)
            {
                connect.Open();
            }
        }
        //-------------------------- METODO PARA CERRRAR CON LA BASE DE DATOS----------------------------------
        public void Descdb()
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }
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
       /* public void Registro()
        {
            comand = new SqlCommand();
            obtener = "select Nom_usuario from usuarios where Nom_usuario = '" + usuario + "' ";
            Connectdb();
            comand = new SqlCommand(obtener, connect);
            sqlread = comand.ExecuteReader();

            if (sqlread.Read())
            {
                Descdb();
                MessageBox.Show("Error, actualmente existe un nombre de usuario igual, ingrese otro usuario");
            }
            else
            {

                desconectar();
                cmd = new SqlCommand();
                cadenaSql = "insert into usuarios values('" + nombres + "','" + apellidos + "','" + usuario + "','" + password + "','" + fechaNacimiento + "','" + pais + "','" + correo + "')";
                conectar();
                cmd = new SqlCommand(cadenaSql, cnn);
                cmd.ExecuteNonQuery();
                desconectar();
                HttpContext.Current.Response.Redirect("Login.aspx");
                MessageBox.Show("Proceso exitoso, el registro a sido guardado en el sistema");
            }
        }
        /*
        public void Login(string user, string pass)
        {
            comand = new SqlCommand();
            cadenaSql = "select nombre_usuario from usuarios where nombre_usuario='" + user + "' and pass='" + pass + "' ";
            conectar();
            cmd = new SqlCommand(cadenaSql, cnn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HttpContext.Current.Response.Redirect("Menu.aspx");
                desconectar();

            }
            else
            {
                MessageBox.Show("Error, el ingreso de usuario o contraseña es incorrecto");
                desconectar();
            }

        }

        public static implicit operator Var(Rusuario v)
        {
            throw new NotImplementedException();
        }*/
    }
}