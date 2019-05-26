using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioTEC.Objects
{
    public class sale
    {
        public string nombre { set; get; }
        public string descripcion { set; get; }
        public DateTime fechaInicio { set; get; }
        public DateTime fechaFinalizacion { set; get; }
        public int porcentajeDescuento { set; get; }
    }
}