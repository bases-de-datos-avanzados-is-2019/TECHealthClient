using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BiblioTEC.Logic;
using Newtonsoft.Json.Linq;

namespace BiblioTEC.GUI
{
    public partial class mainAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                reportesTab2.Visible = false;
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

                DDList_Cantidad.Items.Add(p1);
                DDList_Cantidad.Items.Add(p2);
                DDList_Cantidad.Items.Add(p3);
                DDList_Cantidad.Items.Add(p4);
                DDList_Cantidad.Items.Add(p5);
                DDList_Cantidad.Items.Add(p6);
                DDList_Cantidad.Items.Add(p7);

                DDList_Cantidad.DataBind();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                errorAlert.Visible = false;
                populatePromotions();
                populateBooks();
                populateBookStores();
                getRango();
                getTheme();
                getTopBooks();
                getTopClients();
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

        protected void getRango()
        {
            rangeList.Controls.Clear();
            requestManager request = new requestManager();
            JArray result = request.getRango();

            for(int i = 0; i < result.Count; i++)
            {
                dynamic json = result.ElementAt(i);
                string usuario = json.nombreUsuario;
                int min = 0;
                int max = 0;

                try
                {
                    min = json.minPedidos;
                    max = json.maxPedidos;
                } catch (Exception e)
                {
                    min = 0;
                    max = 0;
                }
                


                HtmlGenericControl temp = addToRange(usuario, min, max);
                rangeList.Controls.Add(temp);
            }
        }

        protected void getTheme()
        {
            themeList.Controls.Clear();
            requestManager request = new requestManager();
            JArray result = request.getTheme();

            for (int i = 0; i < result.Count; i++)
            {
                dynamic json = result.ElementAt(i);
                string tema = json.tema;
                int cantidad = 0;
                int monto = 0;

                try
                {
                    cantidad = json.cantidadVendida;
                    monto = json.montoPromedio;
                }
                catch (Exception e)
                {
                    cantidad = 0;
                    monto = 0;
                }



                HtmlGenericControl temp = addToTheme(tema, cantidad, monto);
                themeList.Controls.Add(temp);
            }
        }

        protected void getTopBooks()
        {
            topBookList.Controls.Clear();
            requestManager request = new requestManager();
            JArray result = request.getTopBooks();

            for (int i = 0; i < result.Count; i++)
            {
                dynamic json = result.ElementAt(i);
                string nombre = json.nombre;
                int cantidad = 0;
                

                try
                {
                    cantidad = json.cantidadVendida;
                    
                }
                catch (Exception e)
                {
                    cantidad = 0;
                    
                }



                HtmlGenericControl temp = addToTopBooks(nombre, cantidad);
                topBookList.Controls.Add(temp);
            }
        }

        protected void getTopClients()
        {
            topClientList.Controls.Clear();
            requestManager request = new requestManager();
            JArray result = request.getTopClients();

            for (int i = 0; i < result.Count; i++)
            {
                dynamic json = result.ElementAt(i);
                string nombre = json._id;
                int cantidad = 0;


                try
                {
                    cantidad = json.pedidos;

                }
                catch (Exception e)
                {
                    cantidad = 0;

                }



                HtmlGenericControl temp = addTopClients(nombre, cantidad);
                topClientList.Controls.Add(temp);
            }
        }

        protected HtmlGenericControl addToRange(string usuario, int min, int max)
        {
            HtmlGenericControl element = new HtmlGenericControl("a");
            element.Attributes.Add("class", "list-group-item list-group-item-action flex-column align-items-start");
            element.Attributes.Add("runat", "server");

            HtmlGenericControl cabecera = new HtmlGenericControl("div");
            cabecera.Attributes.Add("class", "d-flex justify-content-between");

            HtmlGenericControl nombreLibro = new HtmlGenericControl("h5");
            nombreLibro.Attributes.Add("class", "mb-1");
            nombreLibro.InnerText = usuario;

            HtmlGenericControl minQ = new HtmlGenericControl("p");
            minQ.Attributes.Add("style", "color:blue");
            minQ.InnerText = "Minima cantidad de libros comprados: " + min;

            HtmlGenericControl maxQ = new HtmlGenericControl("p");
            maxQ.Attributes.Add("style", "color:blue");
            maxQ.InnerText = "Maxima cantidad de libros comprados: " + max;

            cabecera.Controls.Add(nombreLibro);

            element.Controls.Add(cabecera);
            element.Controls.Add(minQ);
            element.Controls.Add(maxQ);

            return element;
        }

        protected HtmlGenericControl addToTheme(string tema, int cantidadV, int promedio)
        {
            HtmlGenericControl element = new HtmlGenericControl("a");
            element.Attributes.Add("class", "list-group-item list-group-item-action flex-column align-items-start");
            element.Attributes.Add("runat", "server");

            HtmlGenericControl cabecera = new HtmlGenericControl("div");
            cabecera.Attributes.Add("class", "d-flex justify-content-between");

            HtmlGenericControl nombreLibro = new HtmlGenericControl("h5");
            nombreLibro.Attributes.Add("class", "mb-1");
            nombreLibro.InnerText = tema;

            HtmlGenericControl minQ = new HtmlGenericControl("p");
            minQ.Attributes.Add("style", "color:blue");
            minQ.InnerText = "Cantidad de libros vendidos: " + cantidadV;

            HtmlGenericControl maxQ = new HtmlGenericControl("p");
            maxQ.Attributes.Add("style", "color:blue");
            maxQ.InnerText = "Monto Promerio de libros vendidos: $" + promedio;

            cabecera.Controls.Add(nombreLibro);

            element.Controls.Add(cabecera);
            element.Controls.Add(minQ);
            element.Controls.Add(maxQ);

            return element;
        }

        protected HtmlGenericControl addToTopBooks(string nombre, int cantidadV)
        {
            HtmlGenericControl element = new HtmlGenericControl("a");
            element.Attributes.Add("class", "list-group-item list-group-item-action flex-column align-items-start");
            element.Attributes.Add("runat", "server");

            HtmlGenericControl cabecera = new HtmlGenericControl("div");
            cabecera.Attributes.Add("class", "d-flex justify-content-between");

            HtmlGenericControl nombreLibro = new HtmlGenericControl("h5");
            nombreLibro.Attributes.Add("class", "mb-1");
            nombreLibro.InnerText = nombre;

            HtmlGenericControl minQ = new HtmlGenericControl("p");
            minQ.Attributes.Add("style", "color:blue");
            minQ.InnerText = "Cantidad de libros vendidos: " + cantidadV;

            cabecera.Controls.Add(nombreLibro);

            element.Controls.Add(cabecera);
            element.Controls.Add(minQ);
            

            return element;
        }

        protected HtmlGenericControl addTopClients(string _id, int pedidos)
        {
            HtmlGenericControl element = new HtmlGenericControl("a");
            element.Attributes.Add("class", "list-group-item list-group-item-action flex-column align-items-start");
            element.Attributes.Add("runat", "server");

            HtmlGenericControl cabecera = new HtmlGenericControl("div");
            cabecera.Attributes.Add("class", "d-flex justify-content-between");

            HtmlGenericControl nombreLibro = new HtmlGenericControl("h5");
            nombreLibro.Attributes.Add("class", "mb-1");
            nombreLibro.InnerText = _id;

            HtmlGenericControl minQ = new HtmlGenericControl("p");
            minQ.Attributes.Add("style", "color:blue");
            minQ.InnerText = "Cantidad de libros comprados: " + pedidos;

            cabecera.Controls.Add(nombreLibro);

            element.Controls.Add(cabecera);
            element.Controls.Add(minQ);


            return element;
        }

        protected void tabListas_Click(object sender, EventArgs e)
        {
            reportesTab1.Visible = true;
            reportesTab2.Visible = false;

            tabClientes.Attributes.Remove("class");
            tabClientes.Attributes.Add("class", "nav-link active");

            tabPedidos.Attributes.Remove("class");
            tabPedidos.Attributes.Add("class", "nav-link");

            getTopBooks();
            getTheme();
            getRango();
        }

        protected void tabPedidos_Click(object sender, EventArgs e)
        {

            reportesTab1.Visible = false;
            reportesTab2.Visible = true;

            tabClientes.Attributes.Remove("class");
            tabClientes.Attributes.Add("class", "nav-link");

            tabPedidos.Attributes.Remove("class");
            tabPedidos.Attributes.Add("class", "nav-link active");

            getTopClients();

        }

        protected void tabLibros(object sender, EventArgs e)
        {
            vLibros.Attributes.Remove("aria-selected");
            vLibreria.Attributes.Remove("aria-selected");
            vPromociones.Attributes.Remove("aria-selected");
            vEliminar.Attributes.Remove("aria-selected");
            vReportes.Attributes.Remove("aria-selected");

            vLibros.Attributes.Add("aria-selected", "true");
            vLibreria.Attributes.Add("aria-selected", "false");
            vPromociones.Attributes.Add("aria-selected", "false");
            vEliminar.Attributes.Add("aria-selected", "false");
            vReportes.Attributes.Add("aria-selected", "false");

        }

        protected void tabLibrerias(object sender, EventArgs e)
        {
            vLibros.Attributes.Remove("aria-selected");
            vLibreria.Attributes.Remove("aria-selected");
            vPromociones.Attributes.Remove("aria-selected");
            vEliminar.Attributes.Remove("aria-selected");
            vReportes.Attributes.Remove("aria-selected");

            vLibros.Attributes.Add("aria-selected", "false");
            vLibreria.Attributes.Add("aria-selected", "true");
            vPromociones.Attributes.Add("aria-selected", "false");
            vEliminar.Attributes.Add("aria-selected", "false");
            vReportes.Attributes.Add("aria-selected", "false");

        }

        protected void tabPromociones(object sender, EventArgs e)
        {
            vLibros.Attributes.Remove("aria-selected");
            vLibreria.Attributes.Remove("aria-selected");
            vPromociones.Attributes.Remove("aria-selected");
            vEliminar.Attributes.Remove("aria-selected");
            vReportes.Attributes.Remove("aria-selected");

            vLibros.Attributes.Add("aria-selected", "false");
            vLibreria.Attributes.Add("aria-selected", "false");
            vPromociones.Attributes.Add("aria-selected", "true");
            vEliminar.Attributes.Add("aria-selected", "false");
            vReportes.Attributes.Add("aria-selected", "false");

        }

        protected void tabEliminar(object sender, EventArgs e)
        {
            vLibros.Attributes.Remove("aria-selected");
            vLibreria.Attributes.Remove("aria-selected");
            vPromociones.Attributes.Remove("aria-selected");
            vEliminar.Attributes.Remove("aria-selected");
            vReportes.Attributes.Remove("aria-selected");

            vLibros.Attributes.Add("aria-selected", "false");
            vLibreria.Attributes.Add("aria-selected", "false");
            vPromociones.Attributes.Add("aria-selected", "false");
            vEliminar.Attributes.Add("aria-selected", "true");
            vReportes.Attributes.Add("aria-selected", "false");

        }

        protected void tabReportes(object sender, EventArgs e)
        {
            vLibros.Attributes.Remove("aria-selected");
            vLibreria.Attributes.Remove("aria-selected");
            vPromociones.Attributes.Remove("aria-selected");
            vEliminar.Attributes.Remove("aria-selected");
            vReportes.Attributes.Remove("aria-selected");

            vLibros.Attributes.Add("aria-selected", "false");
            vLibreria.Attributes.Add("aria-selected", "false");
            vPromociones.Attributes.Add("aria-selected", "false");
            vEliminar.Attributes.Add("aria-selected", "false");
            vReportes.Attributes.Add("aria-selected", "true");

          

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string tema = DDList_Cantidad.SelectedItem.Text;
            string fechaInicio = txtFechaInicio.Text;
            fechaInicio = fechaInicio + "T00:00:00.000Z";
            DateTime inicio = DateTime.ParseExact(fechaInicio, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
            string fechaFinal = txtFechaFinal.Text;
            fechaFinal = fechaFinal + "T00:00:00.000Z";
            DateTime final = DateTime.ParseExact(fechaFinal, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
            string filtro = txtBuscar.Text;
            bool fechabool = checkFecha.Checked;
            bool temaBool = checkTema.Checked;
            bool clientebool = checkCliente.Checked;
            bool estadobool = checkEstado.Checked;
            List<string> filters = new List<string>();

            if (fechabool)
            {
                filters.Add("fechas");
            }

            if (temaBool)
            {
                filters.Add("tema");
            }

            if (clientebool)
            {
                filters.Add("IdCliente");
            }
            if (estadobool)
            {
                filters.Add("estado");
            }

            string[] filtross = filters.ToArray();

            requestManager request = new requestManager();
            int result = request.getQuantityOrders(filtro, filtro, inicio, final, tema, filtross);

            txtResultadoCantidad.InnerText = result.ToString();
            getTopClients();
        }

    }
}