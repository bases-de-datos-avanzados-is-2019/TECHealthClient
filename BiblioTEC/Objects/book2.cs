using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioTEC.Objects
{
    public class book2
    {
        public string nombre { set; get; }
        public string tema { set; get; }
        public string descripcion { set; get; }
        public string libreria { set; get; }
        public int cantidadVendida { set; get; }
        public int cantidadDisponible { set; get; }
        public string foto { set; get; }
        public int precioDolares { set; get; }
    }
}