using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;


namespace BiblioTEC.Objects
{
    public class orden
    {
        public string IdCliente { set; get; }
        public int[] libros { set; get; }
        public int montoTotal { set; get; }
        public string direccionEntrega { set; get; }
        
    }
}