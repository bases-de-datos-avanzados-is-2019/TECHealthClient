using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiblioTEC.GUI
{
    public partial class historialCliente : System.Web.UI.Page
    {
        private string user;
        protected void Page_Load(object sender, EventArgs e)
        {

            string path = HttpContext.Current.Request.Url.AbsolutePath;
            path = path.Replace("/", ",");
            string[] elements = path.Split(',');

            this.user = elements[elements.Length - 1];

        }

        protected void logOut(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/login.aspx");
        }

        protected void editarInfo(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/crearCuenta.aspx/" + this.user);
        }

        protected void verHistorial(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/login.aspx");
        }

        protected void btnBuscar_Click (object sender, EventArgs e)
        {

        }
    }
}