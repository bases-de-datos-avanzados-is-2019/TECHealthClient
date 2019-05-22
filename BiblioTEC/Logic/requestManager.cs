using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioTEC.Objects;

namespace BiblioTEC.Logic
{
    public class requestManager
    {
        private restClient client;
        private string IP = "";
        private string PORT = "";
        private string URL = "";

        /*
         *  Constructor para la clase request manager
         */
        public requestManager()
        {
            // Se crea la instancia del cliente
            this.client = new restClient();
            // Se especifican la IP y puerto a los que se desea conectar
            this.IP = "localhost";
            this.PORT = "3000";
            // Se arma el URL
            this.URL = "http://" + IP + ":" + PORT + "/api/";
            this.URL = "https://library-tec.herokuapp.com/api/";

        }

        /*
         *  LogIn del usuario
         */
        public string[] logIn(string id, string password)
        {
            // string[] de respuesta
            string idUsuario = "";
            string tipoUsuario = "";
            string[] result = new string[2];

            // Consulta
            string requestType = "logIn/";
            logIn usuario = new logIn();
            usuario.user = id;
            usuario.password = password;
            string json = JsonConvert.SerializeObject(usuario);

            //this.URL = this.URL + requestType + json;
            this.client.endPoint = this.URL + requestType + json;


             string getrequest = client.makeRequest(2);
          
             getrequest = getrequest.Replace("\"", "'");
             dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);
             idUsuario = jsonResult.id;
             tipoUsuario = jsonResult.tipoUsuario;

             // Llenado del array
             result[0] = idUsuario;
             result[1] = tipoUsuario;

            // Resultado de la consulta
            return result;
        }

        public string testConnection()
        {
            string respuesta = "";
            this.client.endPoint = this.URL;

            string getrequest = client.makeRequest(1);
            getrequest = getrequest.Replace("\"","'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);
            respuesta = jsonResult.mensaje;

            return respuesta;

        }

        public string crearCuenta(string nombre, string primerApellido, string segundoApellido, int cedula, string fechaNacimiento, string tipoUsuario, string ubicacion, string correoElectronico, string nombreUsuario, string password, string[] telefonos)
        {

           
            user usuario = new user() {

                nombre = nombre,
                primerApellido = primerApellido,
                segundoApellido = segundoApellido,
                cedula = cedula,
                fechaNacimiento = fechaNacimiento,
                tipoUsuario = tipoUsuario,
                ubicacion = ubicacion,
                correoElectronico = correoElectronico,
                nombreUsuario = nombreUsuario,
                password = password,
                telefonos = telefonos

            };

            string requestype = "user/";
            string json = JsonConvert.SerializeObject(usuario);

            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(2);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;
            return result;

        }

        public book[] GetBooks(string nombre, string libreria, string tema, int precioMin, int precioMax, string[] filtros)
        {
            bookSearch libros = new bookSearch()
            {
                nombre = nombre,
                libreria = libreria,
                tema = tema,
                precioMin = precioMin,
                precioMax = precioMax,
                filtros = filtros
            };

            string requestype = "book/";
            string json = JsonConvert.SerializeObject(libros);

            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(1);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string[] result = jsonResult.resultado;
            book[] resultado = new book[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                dynamic libroJson = JsonConvert.DeserializeObject(result[i]);

                book temp = new book()
                {
                    issn = libroJson.issn,
                    nombre = libroJson.nombre,
                    tema = libroJson.tema,
                    descripcion = libroJson.descripcion,
                    libreria = libroJson.libreria,
                    cantidadVendida = libroJson.cantidadVendida,
                    cantidadDisponible = libroJson.cantidadDisponible,
                    foto = libroJson.foto,
                    precioDolares = libroJson.precioDolares

                };

                resultado[i] = temp;
            }

            return resultado;
        }

        public book[] GetBooks()
        {
            bookSearch libros = new bookSearch()
            {
                nombre = string.Empty,
                libreria = string.Empty,
                tema = string.Empty,
                precioMin = 0,
                precioMax = 0,
                filtros = new string[0]
            };

            string requestype = "book/";
            string json = JsonConvert.SerializeObject(libros);

            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(1);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            JArray result = jsonResult.resultado;
            book[] resultado = new book[result.Count];

            for (int i = 0; i < result.Count; i++)
            {
                dynamic libroJson = result.ElementAt(i);

                book temp = new book()
                {
                    issn = libroJson.issn,
                    nombre = libroJson.nombre,
                    tema = libroJson.tema,
                    descripcion = libroJson.descripcion,
                    libreria = libroJson.libreria,
                    cantidadVendida = libroJson.cantidadVendida,
                    cantidadDisponible = libroJson.cantidadDisponible,
                    foto = libroJson.foto,
                    precioDolares = libroJson.precioDolares

                };

                resultado[i] = temp;
            }

            return resultado;
        }


    }
}