using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BiblioTEC.Logic;


namespace BiblioTEC.GUI
{
    public partial class login : System.Web.UI.Page
    {

        private int error;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                errorAlert.Visible = false;
                error = 0;
            }

        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/crearCuenta.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //Response.Redirect("~/GUI/main.aspx");
            requestManager request = new requestManager();

            string id = txtIdentificacion.Text;
             string pass = txtPassword.Text;

             string[] result = request.logIn(id, pass);

             switch (result[1])
             {
                 case "cliente":
                    Application["LibrosOrden"] = "libros";
                    Response.Redirect("~/GUI/main.aspx/" + result[0]);
                     break;

                 case "agente":
                     //Response.Redirect("~/GUI/mainAgente.aspx/" + result[0]);

                     break;

                case "gerente":
                    Application["LIBRERIA"] = result[2];
                    //Response.Redirect("~/GUI/mainAgente.aspx/" + result[0]);
                    txtIdentificacion.Text = result[2];

                    break;

                case "administradr":
                     Response.Redirect("~/GUI/mainAdmin.aspx/" + result[0]);
                     break;

                 default:
                    showAlert(result[1]);
                     break;
             }

            //txtIdentificacion.Text = request.testConnection();
            


        }

        protected void recuperarContrasena_Click(object sender, EventArgs e)
        {

        }

        protected void showAlert(string message)
        {
            errorAlert.InnerText = message;
            errorAlert.Visible = true;
        }


    }
}