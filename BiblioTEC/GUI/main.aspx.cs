using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Google.Cloud.Translation.V2;
using Google.Apis.Auth.OAuth2;
using BiblioTEC.Objects;

namespace BiblioTEC.GUI
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string path = HttpContext.Current.Request.Url.AbsolutePath;
                path = path.Replace("/", ",");
                string[] elements = path.Split(',');

                string userId= elements[elements.Length - 1];

                getBooks(20);
                

            }
            
        }

        protected void btnCarrito_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/crearCuenta.aspx");
        }

        protected HtmlGenericControl NuevoLibro (string nombre, string tema, string precio, string id)
        {
 
            HtmlGenericControl element = new HtmlGenericControl("a");
            element.Attributes.Add("class", "list-group-item list-group-item-action flex-column align-items-start");
            element.Attributes.Add("runat", "server");
            element.Attributes.Add("href", "crearCuenta.aspx/" + id);

            HtmlGenericControl titulo = new HtmlGenericControl("div");
            titulo.Attributes.Add("class", "d-flex justify-content-between");

            HtmlGenericControl nombreLibro = new HtmlGenericControl("h5");
            nombreLibro.Attributes.Add("class", "mb-1");
            nombreLibro.InnerText = nombre;

            HtmlGenericControl idLibro = new HtmlGenericControl("p");
            idLibro.Attributes.Add("style", "color:blue");
            idLibro.InnerText = "$" + precio;

            HtmlGenericControl precioLibro = new HtmlGenericControl("small");
            precioLibro.Attributes.Add("class", "text-muted");
            precioLibro.InnerText = id;

            HtmlGenericControl temaLibro = new HtmlGenericControl("small");
            temaLibro.InnerText = tema;

            nombreLibro.Controls.Add(idLibro);

            titulo.Controls.Add(nombreLibro);
            titulo.Controls.Add(precioLibro);

            element.Controls.Add(titulo);
            element.Controls.Add(temaLibro);

            return element;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            /* string text = txtBuscar.Text;
             // string selection = DDList_Idiomas.SelectedItem.Text;

             var credential = GoogleCredential.FromFile("D:/TEC/Projects/BiblioTEC/GoogleCredentials.json");


             TranslationClient client = TranslationClient.Create(credential);
             var response = client.TranslateText(text, "ru");

             resultadoTranslate.InnerText = response.ToString();*/
            int quantity = Int32.Parse(txtBuscar.Text);
            getBooks(quantity);
            bool libreBool = checkLibreria.Checked;
            bool temaBool = checkTema.Checked;
            bool precioBool = checkPrecio.Checked;
            bool nombreBool = checkNombre.Checked;
        }

        protected void getBooks(int identifier)
        {
            List<HtmlGenericControl> result = new List<HtmlGenericControl>();
            
               
            for (int i = 0; i < (identifier +1) ; i++)
            {
                HtmlGenericControl temp = NuevoLibro("titulo del libro", "tema del libro", "32", "" + i);
                result.Add(temp);
            }

            bookList.Controls.Clear();
            bookList2.Controls.Clear();

            //int lengh = Arr.lengh();
            int lengh = result.Count - 1;
            int midway = lengh / 2;
            int remainder = lengh - midway;



            for (int i = 0; i < (remainder + 1); i++)
            {

                HtmlGenericControl temp = result.ElementAt(i);
                bookList.Controls.Add(temp);
                // booklist2.Controls.Add(temp);

            }

            for (int i = remainder; i < (midway + 1); i++)
            {

                HtmlGenericControl temp = result.ElementAt(i);
                //bookList.Controls.Add(temp);
                bookList2.Controls.Add(temp);

            }
        }
    }
}