using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BiblioTEC.Logic;

namespace BiblioTEC.GUI
{
    public partial class crearCuenta : System.Web.UI.Page
    {
        private string user;
        private bool isEdit = false;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                ListItem m = new ListItem("Regular"    , "1");
                ListItem m2 = new ListItem("Frecuente" , "2");

                DDList_tipoCliente.Items.Add(m);
                DDList_tipoCliente.Items.Add(m2);

                DDList_tipoCliente.DataBind();



                ListItem p1 = new ListItem("San Jose"   , "1");
                ListItem p2 = new ListItem("Alajuela"   , "2");
                ListItem p3 = new ListItem("Cartago"    , "3");
                ListItem p4 = new ListItem("Heredia"    , "4");
                ListItem p5 = new ListItem("Puntarenas" , "5");
                ListItem p6 = new ListItem("Guanacaste" , "6");
                ListItem p7 = new ListItem("Limon"      , "7");

                DDList_ubicacion.Items.Add(p1);
                DDList_ubicacion.Items.Add(p2);
                DDList_ubicacion.Items.Add(p3);
                DDList_ubicacion.Items.Add(p4);
                DDList_ubicacion.Items.Add(p5);
                DDList_ubicacion.Items.Add(p6);
                DDList_ubicacion.Items.Add(p7);

                DDList_ubicacion.DataBind();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                errorAlert.Visible = false;

              string path = HttpContext.Current.Request.Url.AbsolutePath;
                path = path.Replace("/", ",");
                string[] elements = path.Split(',');
                
                this.user = elements[elements.Length - 1];

                if (user != "crearCuenta")
                {
                    this.isEdit = true;
                    btnCrearCuenta.Text = "GUARDAR CAMBIOS";
                }


            }
        }

        protected void DDList_tipoCliente_SelectedIndexChanged(object seder, EventArgs e)
        {

        }

        protected void DDList_ubicacion_SelectedIndexChanged(object seder, EventArgs e)
        {

        }

        /*
         * From brave: <3
         */
        protected void btnCrearCuenta_Click(object seder, EventArgs e)
        {
            
            if (this.isEdit)
            {
                try
                {

                    string nombre = txtNombre.Text;
                    string primerApellido = txtApellido1.Text;
                    string segundoApellido = txtApellido2.Text;
                    int cedula = Int32.Parse(txtCedula.Text);
                    string fecha = txtFechaNacimiento.Text;
                    string tipoCliente = DDList_tipoCliente.SelectedItem.Text;
                    string ubicacion = DDList_ubicacion.SelectedItem.Text;
                    string correo = txtCorreo.Text;
                    string nombreUsuario = txtUsuario.Text;
                    string contra = txtConstrasena.Text;
                    string contra2 = txtContrasenaConfirmacion.Text;

                    string telefonosTemp = txtTelefono.Text;
                    telefonosTemp = telefonosTemp.Replace(" ", String.Empty);
                    string[] telefonos = telefonosTemp.Split(',');



                    if (contra.Equals(contra2))
                    {
                        requestManager request = new requestManager();
                        string result = request.crearCuenta(nombre, primerApellido, segundoApellido, cedula, fecha, "cliente", ubicacion, correo, nombreUsuario, contra, telefonos, 3);

                        if (result == "aceptado")
                        {
                            Response.Redirect("~/GUI/login.aspx");
                        }
                        else
                        {
                            showAlert("Ha ocurrido un error a la hora de registrar su usuario");
                            //showAlert(result);
                        }
                    }
                    else
                    {
                        showAlert("Las contrasenas ingresadas no coinciden. Intentalo nuevamente!");
                    }

                }
                catch (Exception ex)
                {
                    showAlert(ex.Message + " " + ex.Source + "" + ex.StackTrace);

                }

            }
            else
            {
                try
                {

                    string nombre = txtNombre.Text;
                    string primerApellido = txtApellido1.Text;
                    string segundoApellido = txtApellido2.Text;
                    int cedula = Int32.Parse(txtCedula.Text);
                    string fecha = txtFechaNacimiento.Text;
                    string tipoCliente = DDList_tipoCliente.SelectedItem.Text;
                    string ubicacion = DDList_ubicacion.SelectedItem.Text;
                    string correo = txtCorreo.Text;
                    string nombreUsuario = txtUsuario.Text;
                    string contra = txtConstrasena.Text;
                    string contra2 = txtContrasenaConfirmacion.Text;

                    string telefonosTemp = txtTelefono.Text;
                    telefonosTemp = telefonosTemp.Replace(" ", String.Empty);
                    string[] telefonos = telefonosTemp.Split(',');



                    if (contra.Equals(contra2))
                    {
                        requestManager request = new requestManager();
                        string result = request.crearCuenta(nombre, primerApellido, segundoApellido, cedula, fecha, "cliente", ubicacion, correo, nombreUsuario, contra, telefonos, 2);

                        if (result == "aceptado")
                        {
                            Response.Redirect("~/GUI/login.aspx");
                        }
                        else
                        {
                            showAlert("Ha ocurrido un error a la hora de registrar su usuario");
                            //showAlert(result);
                        }
                    }
                    else
                    {
                        showAlert("Las contrasenas ingresadas no coinciden. Intentalo nuevamente!");
                    }

                }
                catch (Exception ex)
                {
                    showAlert(ex.Message + " " + ex.Source + "" + ex.StackTrace);

                }

            }
            
        }

        protected void showAlert(string message)
        {
            errorAlert.InnerText = message;
            errorAlert.Visible = true;
        }
    }
}