using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BiblioTEC.Logic;
using BiblioTEC.Objects;

namespace BiblioTEC.GUI
{
    public partial class carritoCliente : System.Web.UI.Page
    {
        private int precioTotal;
        private int descuento;
        private List<int> orderBooks;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            this.orderBooks = new List<int>();
            if (!IsPostBack)
            {
                this.orderBooks = new List<int>();
                getBooks();
                calcularOferta();


                txtDescuento.InnerText = "DESCUENTO APLICADO A LA ORDEN: -$" + this.descuento;
                txtPrecioTotal.InnerText = "PRECIO TOTAL DE LA ORDEN: $" + this.precioTotal;
            }
        }

        protected HtmlGenericControl getOrderDets (string nombre, string precio)
        {
            HtmlGenericControl element = new HtmlGenericControl("a");
            element.Attributes.Add("class", "list-group-item list-group-item-action flex-column align-items-start");

            HtmlGenericControl titulo = new HtmlGenericControl("div");
            titulo.Attributes.Add("class", "d-flex justify-content-between");

            HtmlGenericControl nombreLibro = new HtmlGenericControl("h5");
            nombreLibro.Attributes.Add("class", "mb-1");
            nombreLibro.InnerText = nombre;

            HtmlGenericControl idLibro = new HtmlGenericControl("p");
            idLibro.Attributes.Add("style", "color:blue");
            idLibro.InnerText = "$" + precio;

            nombreLibro.Controls.Add(idLibro);
            titulo.Controls.Add(nombreLibro);
            element.Controls.Add(titulo);

            return element;


        }

        protected void getBooks ()
        {
            this.precioTotal = 0;
            string books = Application["LibrosOrden"].ToString();
            string[] ids = books.Split(',');

            for (int i = 0; i < ids.Length; i++)
            {
                if(ids[i] != "libros")
                {
                    requestManager request = new requestManager();
                    string[] filtro = new string[1];
                    filtro[0] = "issn";

                    int book = Int32.Parse(ids[i]);
                    orderBooks.Add(book);
                    book[] libros = request.GetBooks(string.Empty, string.Empty, string.Empty, book, 0, filtro);
                    this.precioTotal = this.precioTotal + libros[0].precioDolares;
                    HtmlGenericControl temp = getOrderDets(libros[0].nombre, libros[0].precioDolares.ToString());
                    bookList.Controls.Add(temp);
                }
            }
        }

        protected void calcularOferta()
        {
            requestManager request = new requestManager();
            int oferta = request.getSales();
            //int oferta = 30;

            double temp = (this.precioTotal * oferta) / 100;
            int temp2 = (int)Math.Round(temp);

            this.descuento = temp2;
            this.precioTotal = this.precioTotal - temp2;

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            string user = Application["USER"].ToString();
            string books = Application["LibrosOrden"].ToString();
            books = books.Replace("libros,", string.Empty);
            string[] ids = books.Split(',');
            int[] bookArr = new int[books.Length];
            int precio = this.precioTotal;

            string tots = txtPrecioTotal.InnerText.ToString();
            tots = tots.Replace("PRECIO TOTAL DE LA ORDEN: $", string.Empty);

            precio = Int32.Parse(tots);
            
            for (int i = 0; i < ids.Length; i++)
            {
                bookArr[i] = Int32.Parse(ids[i]);
            }

            List<int> test = new List<int>();

            for(int i = 0; i < bookArr.Length; i++)
            {
                if(bookArr[i] != 0)
                {
                    test.Add(bookArr[i]);
                }
            }

            bookArr = new int[test.Count];

            for(int i = 0; i< test.Count; i++)
            {
                bookArr[i] = test.ElementAt(i);
            }

            requestManager request = new requestManager();
            string ubicacion = request.getAdress(user);
            placeOrder(user, bookArr, ubicacion, precio);

            
            
        }

        protected void placeOrder(string id, int[] books, string address, int price)
        {
            requestManager request = new requestManager();
            string result = request.placeOrder(id, books, address, price);

            if (result == "Orden guardada")
            {
                showAlert("Su Orden ha sido procesada exitosamente");
                string user = Application["USER"].ToString();
                Application["LibrosOrden"] = "libros";
                Response.Redirect("~/GUI/main.aspx/" + user);
            } else
            {
                showAlert(result);
            }
        }

        protected void showAlert(string message)
        {
            errorAlert.InnerText = message;
            errorAlert.Visible = true;
        }



    }
}