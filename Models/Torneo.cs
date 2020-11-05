using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Models
{
    public class Torneo
    {
        public string Equipo { get; set; }
        public string Integrantes { get; set; }
        public string Estado { get; set; }
        public string Color { get; set; }
        public int Index { get; set; }
        public string Nombre_torneo { get; set; }

    }
}