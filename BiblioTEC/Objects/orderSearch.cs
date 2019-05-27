using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioTEC.Objects
{
    public class orderSearch
    {
        public string idCliente { set; get; }
        public string estado { set; get; }
        public DateTime fechaMin { set; get; }
        public DateTime fechaMax { set; get; }
        public string tema { set; get; }
        public string[] filtros { set; get; }
    }
}