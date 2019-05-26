using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BiblioTEC.Logic;

namespace BiblioTEC.GUI
{
    public partial class mainAdmin : System.Web.UI.Page
    {
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

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                errorAlert.Visible = false;
                populatePromotions();
                populateBooks();
                populateBookStores();
                
            }
        

        }

        protected void btnLibros_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = txtTitulo.Text;
                string tema = DDList_tema.SelectedItem.Text;
                string libreria = txtLibreria.Text;
                string foto = txtFoto.Text;
                string descripcion = txtDescripcion.Text;
                int cantidadV = Int32.Parse(txtCantidadVendida.Text);
                int cantidadD = Int32.Parse(txtCantidadDisponible.Text);
                int precio = Int32.Parse(txtPrecio.Text);

                foto = foto.Replace("/","%2F");

                requestManager request = new requestManager();
                string resultado = request.insertBook(titulo, libreria, tema, descripcion, foto, cantidadV, cantidadD, precio);

                if (resultado != "Libro guardado")
                {
                    showAlert(resultado);
                }
                else
                {
                    txtTitulo.Text = string.Empty;
                    DDList_tema.SelectedItem.Text = "Ingenieria";
                    txtLibreria.Text = string.Empty;
                    txtFoto.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtCantidadDisponible.Text = string.Empty;
                    txtCantidadVendida.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    DDList_DeleteLibro.Items.Clear();
                    populateBooks();
                }
            } catch (Exception ex)
            {
                showAlert("Error a la hora de ingresar los datos");
                
            }

        }

        protected void btnLibrerias_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreLibreria.Text;
            string pais = txtPaisLibreria.Text;
            string telefono = txtTelefonoLibreria.Text;
            string horario = txtHorarioLibreria.Text;
            string detalle = txtDetalleLibreria.Text;

            requestManager request = new requestManager();
            string resultado = request.insertBookStore(nombre, pais, telefono, horario, detalle);

            if(resultado != "Libreria guardada")
            {
                showAlert(resultado);
            } else
            {
                txtNombreLibreria.Text = string.Empty;
                txtPaisLibreria.Text = string.Empty;
                txtTelefonoLibreria.Text = string.Empty;
                txtHorarioLibreria.Text = string.Empty;
                txtDetalleLibreria.Text = string.Empty;
                DDList_DeleteLibreria.Items.Clear();
                populateBookStores();
            }
        }

        protected void btnPromociones_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtPromocionNombre.Text;
                string descripcion = txtPromocionDescripcion.Text;
                string fechaInicio = txtPromocionFInicio.Text;
                fechaInicio = fechaInicio + "T00:00:00.000Z";
                DateTime inicio = DateTime.ParseExact(fechaInicio, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
                string fechaFinal = txtPromocionFFinal.Text;
                fechaFinal = fechaFinal + "T00:00:00.000Z";
                DateTime final = DateTime.ParseExact(fechaFinal, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
                int descuento = Int32.Parse(txtPromocionDescuento.Text);

                requestManager request = new requestManager();
                string resultado = request.insertPromotion(nombre, descripcion, inicio, final, descuento);

                if (resultado != "Oferta guardada")
                {
                    showAlert(resultado);
                }
                else
                {
                    txtPromocionDescripcion.Text = string.Empty;
                    txtPromocionDescuento.Text = string.Empty;
                    txtPromocionNombre.Text = string.Empty;
                    txtPromocionFInicio.Text = string.Empty;
                    txtPromocionFFinal.Text = string.Empty;
                    DDList_DeletePromocion.Items.Clear();
                    populatePromotions();
                }
            } catch (Exception ex)
            {
                showAlert("Error a la hora de ingresar los datos");
            }
        }

        protected void btnReportes_Click (object sender, EventArgs e)
        {
          
        }

        protected void showAlert(string message)
        {
            errorAlert.InnerText = message;
            errorAlert.Visible = true;
        }

        protected void tempAlert()
        {
            showAlert("Success");
            System.Threading.Thread.Sleep(3000);
            errorAlert.Visible = false;
        }

        protected void populatePromotions()
        {
            requestManager request = new requestManager();
            string[] promotions = request.getAllPromotions();

            for(int i = 0; i < promotions.Length; i++)
            {
                ListItem p = new ListItem(promotions[i], "" + i);
                DDList_DeletePromocion.Items.Add(p);
            }

            DDList_DeletePromocion.DataBind();
        }

        protected void populateBooks()
        {
            requestManager request = new requestManager();
            string[,] books = request.getAllBooks();

            for (int i = 0; i < books.GetLength(0); i++)
            {
                ListItem p = new ListItem(books[i,0], books[i,1]);
                DDList_DeleteLibro.Items.Add(p);
            }

            DDList_DeleteLibro.DataBind();
        }

        protected void populateBookStores()
        {
            
            requestManager request = new requestManager();
            string[,] bookStores = request.getAllBookStores();

            for (int i = 0; i < bookStores.GetLength(0); i++)
            {
                ListItem p = new ListItem(bookStores[i,0], bookStores[i,1]);
                DDList_DeleteLibreria.Items.Add(p);
            }

            DDList_DeleteLibreria.DataBind();
        }

        protected void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            string bookID = DDList_DeleteLibro.SelectedValue.ToString();
            int issn = Int32.Parse(bookID);
            requestManager request = new requestManager();
            string result = request.deleteBook(issn);

            if(result != "Libro eliminado")
            {
                showAlert("Error a la hora de eliminar el libro");
            } else
            {
                DDList_DeleteLibro.Items.Clear();
                populateBooks();
            }
            
        }

        protected void btnEliminarPromocion_Click(object sender, EventArgs e)
        {
            string promotionName = DDList_DeletePromocion.SelectedItem.Text;
            requestManager request = new requestManager();
            string result = request.deletePromotion(promotionName);

            if(result != "Oferta eliminada")
            {
                showAlert("Error al eliminar la oferta");
            } else
            {
                DDList_DeletePromocion.Items.Clear();
                populatePromotions();
                
            }
            
        }

        protected void btnEliminarLibreria_Click(object sender, EventArgs e)
        {
            string bookID = DDList_DeleteLibreria.SelectedValue.ToString();
            int issn = Int32.Parse(bookID);
            requestManager request = new requestManager();
            string result = request.deleteBookStore(issn);

            if (result != "Libreria eliminada")
            {
                showAlert("Error a la hora de eliminar la libreria");
            }
            else
            {
                DDList_DeleteLibreria.Items.Clear();
                populateBookStores();
            }

        }

    }
}