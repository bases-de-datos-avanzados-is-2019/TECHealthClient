using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioTEC.Objects
{
    public class bookSearch
    {
        public string nombre { set; get; }
        public string libreria { set; get; }
        public string tema { set; get; }
        public int precioMin { set; get; }
        public int precioMax { set; get; }
    }
}