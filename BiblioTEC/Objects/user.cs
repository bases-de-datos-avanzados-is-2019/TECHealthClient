using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioTEC.Objects
{
    public class user
    {
        public string nombre { set; get; }
        public string primerApellido { set; get; }
        public string segundoApellido { set; get; }
        public int cedula { set; get; }
        public string fechaNacimiento { set; get; }
        public string tipoUsuario { set; get; }
        public string ubicacion { set; get; }
        public string correoElectronico { set; get; }
        public string nombreUsuario { set; get; }
        public string password { set; get; }
        public string[] telefonos { set; get; }
    }
}