using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BiblioTEC.Logic;
using BiblioTEC.Objects;

namespace BiblioTEC.GUI
{
    public partial class bookInfo : System.Web.UI.Page
    {
        private string bookId;
        private string user;
        private Image sample = new Image();
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            path = path.Replace("/", ",");
            string[] elements = path.Split(',');

            this.bookId = elements[elements.Length - 1];
            this.user = elements[elements.Length - 2];

            getBookInfo();

          

        }

        protected void logOut (object sender, EventArgs e)
        {
            
            Response.Redirect("~/GUI/login.aspx");
        }

        protected void editarInfo (object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/crearCuenta.aspx/" + this.user);
        }

        protected void verHistorial (object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/login.aspx");
        }

        protected void getBookInfo()
        {
            requestManager request = new requestManager();
            string[] filtro = new string[1];
            filtro[0] = "issn";

            int book = Int32.Parse(this.bookId);

            book[] libros = request.GetBooks(string.Empty, string.Empty, string.Empty, book, 0, filtro);

            string titulo = libros[0].nombre;
            int precio = libros[0].precioDolares;

            int id = libros[0].issn;
            string tema = libros[0].tema;

            string descripcion = libros[0].descripcion;

            bookTitle.InnerText = titulo;
            bookPrice.InnerText = "$" + precio.ToString();
            bookIssn.InnerText = id.ToString();
            bookTheme.InnerText = tema;
            bookDescription.InnerText = descripcion;
        }
    }
}