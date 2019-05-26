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
            if (!IsPostBack)
            {
                ListItem p1 = new ListItem("Ingenieria", "1");
                ListItem p2 = new ListItem("Administracion", "2");
                ListItem p3 = new ListItem("Ciencias Naturales", "3");
                ListItem p4 = new ListItem("Artes", "4");
                ListItem p5 = new ListItem("Historia", "5");
                ListItem p6 = new ListItem("Matematicas", "6");
                ListItem p7 = new ListItem("Realidad", "7");

                DDList_tema.Items.Add(p1);
                DDList_tema.Items.Add(p2);
                DDList_tema.Items.Add(p3);
                DDList_tema.Items.Add(p4);
                DDList_tema.Items.Add(p5);
                DDList_tema.Items.Add(p6);
                DDList_tema.Items.Add(p7);

                DDList_tema.DataBind();

                string path = HttpContext.Current.Request.Url.AbsolutePath;
                path = path.Replace("/", ",");
                string[] elements = path.Split(',');

                this.user = elements[elements.Length - 1];
            }
            
            

        }

        protected void logOut(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/login.aspx");
        }

        protected void editarInfo(object sender, EventArgs e)
        {
            string user = Application["USER"].ToString();
            Response.Redirect("~/GUI/crearCuenta.aspx/" + user);
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