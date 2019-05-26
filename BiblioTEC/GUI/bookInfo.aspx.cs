using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BiblioTEC.Logic;
using BiblioTEC.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Google.Cloud.Translation.V2;
using Google.Apis.Auth.OAuth2;

namespace BiblioTEC.GUI
{
    public partial class bookInfo : System.Web.UI.Page
    {
        private string bookId;
        private string user;
        private book myBook;
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

            this.myBook = libros[0];

            int id = libros[0].issn;
            string tema = libros[0].tema;

            string descripcion = libros[0].descripcion;

            string imgSrc = libros[0].foto;

            int copiasV = libros[0].cantidadVendida;
            int copiasD = libros[0].cantidadDisponible;

            bookTitle.InnerText = titulo;
            bookPrice.InnerText = "$" + precio.ToString();
            bookIssn.InnerText = id.ToString();
            bookTheme.InnerText = tema;
            bookDescription.InnerText = descripcion;
            
            bookCopiasD.InnerText = "Cantidad de libros disponibles: " + copiasD.ToString();
            bookCopiasV.InnerText = "Cantidad de libros vendidos: " + copiasV.ToString();

            try
            {
                bookPhoto.Attributes.Remove("src");
                bookPhoto.Attributes.Add("src", imgSrc);
            } catch (Exception e)
            {
                // something
            }
        }

        protected void btn_AddToCart (object sender, EventArgs e)
        {
            addToCart();
            //translate("hello", "ru");
            Response.Redirect("~/GUI/main.aspx/" + this.user);

        }

        protected void addToCart ()
        {
            string libros = Application["LibrosOrden"].ToString();
            libros = libros + "," + this.myBook.issn;
            
            Application["LibrosOrden"] = libros;
            
        }

        protected string translate (string text,string language)
        {
            var credential = GoogleCredential.FromFile("D:/TEC/Projects/BiblioTEC/GoogleCredentials.json");


            TranslationClient client = TranslationClient.Create(credential);
            var response = client.TranslateText(text, language);

            return response.ToString();
        }
    }
}