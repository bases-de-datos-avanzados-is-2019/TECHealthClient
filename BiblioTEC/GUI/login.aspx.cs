using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiblioTEC.GUI
{
    public partial class login : System.Web.UI.Page
    {

        private int error;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                alertError.Visible = false;
                error = 0;
            }

        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/crearCuenta.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/main.aspx");

        }

        protected void recuperarContrasena_Click(object sender, EventArgs e)
        {

        }


    }
}