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

        public string crearCuenta(string nombre, string primerApellido, string segundoApellido, int cedula, string fechaNacimiento, string tipoUsuario, string ubicacion, string correoElectronico, string nombreUsuario, string password, string[] telefonos, int rType)
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
            //string result = this.client.endPoint;
            string getrequest = client.makeRequest(rType);
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

        public string Prueba(string nombre, string libreria, string tema, int precioMin, int precioMax, string[] filtros)
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
            return this.client.endPoint;
        }

        public dynamic getClient (string id)
        {
            rUser user = new rUser();
            user.id = id;

            string requestype = "user/";
            string json = JsonConvert.SerializeObject(user);

            this.client.endPoint = this.URL + requestype + json;
            
            string getrequest = client.makeRequest(1);
            
            getrequest = getrequest.Replace("\"", "'");
          
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);


            /*user result = new user()
            {
                nombre = jsonResult.nombre,
                primerApellido = jsonResult.primerApellido,
                segundoApellido = jsonResult.segundoApellido,
                cedula = Int32.Parse(jsonResult.cedula),
                nombreUsuario = jsonResult.nombreUsuario,
                fechaNacimiento =jsonResult.fechaNacimiento,
                correoElectronico = jsonResult.correoElectronico,
                ubicacion = jsonResult.ubicacion,
                password = jsonResult.password,
                tipoUsuario = jsonResult.tipoUsuario,
                telefonos = jsonResult.telefonos


            };*/

            return jsonResult;
        }

        public string getAdress(string id)
        {
            rUser user = new rUser();
            user.id = id;

            string requestype = "user/";
            string json = JsonConvert.SerializeObject(user);

            this.client.endPoint = this.URL + requestype + json;

            string getrequest = client.makeRequest(1);

            getrequest = getrequest.Replace("\"", "'");

            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);
            return jsonResult.ubicacion;
        }

        public int getSales()
        {
            string requestype = "offer/aplicables";
            this.client.endPoint = this.URL + requestype;
            string getrequest = client.makeRequest(1);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            JArray resArr = jsonResult.result;

            int temp1 = 0;
            int temp2 = 0;
            
            for (int i = 0; i < resArr.Count; i++)
            {
                dynamic newJson = resArr.ElementAt(i);
                temp1 = newJson.porcentajeDescuento;

                if (temp1 >= temp2)
                {
                    temp2 = temp1;
                } 
            }


  

            return temp2;
        }

        public string placeOrder(string id, int[] books, string address, int price)
        {
            string requestype = "order/";
            orden newOrder = new orden()
            {
                IdCliente = id,
                libros = books,
                direccionEntrega = address,
                montoTotal = price
            
            };

            string json = JsonConvert.SerializeObject(newOrder);
            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(2);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;




            return result;
        }

        public string insertBook (string titulo, string libreria, string tema, string descripcion, string foto, int cantidadV, int cantidadD, int precio)
        {
           
            string requestype = "book/";
            book2 libro = new book2()
            {
                nombre = titulo,
                tema = tema,
                descripcion = descripcion,
                libreria = libreria,
                cantidadVendida = cantidadV,
                cantidadDisponible = cantidadD,
                foto = foto,
                precioDolares = precio

            };
            string json = JsonConvert.SerializeObject(libro);

            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(2);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;
            return result;
        }

        public string insertBookStore(string nombre, string pais, string telefono, string horario, string detalleUbicacion)
        {

            string requestype = "bookStore/";
            bookStore2 libreria = new bookStore2()
            {
                nombre = nombre,
                pais = pais,
                telefono = telefono,
                horario = horario,
                detalleUbicacion = detalleUbicacion

            };
            string json = JsonConvert.SerializeObject(libreria);

            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(2);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;
            return result;
        }

        public string insertPromotion(string nombre, string descripcion, DateTime inicio, DateTime final, int porcentaje)
        {

            string requestype = "offer/";
            sale oferta = new sale()
            {
                nombre = nombre,
                descripcion = descripcion,
                fechaInicio = inicio,
                fechaFinalizacion = final,
                porcentajeDescuento = porcentaje
                

            };
            string json = JsonConvert.SerializeObject(oferta);

            this.client.endPoint = this.URL + requestype + json;
            string getrequest = client.makeRequest(2);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;
            return result;
        }

        public string[] getAllPromotions ()
        {
            string requestype = "offer";
            this.client.endPoint = this.URL + requestype;
            string getrequest = client.makeRequest(1);

            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            JArray Arr = jsonResult.result;

            string[] result = new string[Arr.Count];

            for(int i = 0; i < Arr.Count; i++)
            {
                dynamic json = Arr.ElementAt(i);
                result[i] = json.nombre;
            }

            return result;
        }

        public string[,] getAllBooks()
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
            string[,] resultado = new string[result.Count,2];

            for (int i = 0; i < result.Count; i++)
            {
                dynamic libroJson = result.ElementAt(i);
                resultado[i, 0] = libroJson.nombre;
                resultado[i, 1] = libroJson.issn;
            }

            return resultado;
        }

        public string[,] getAllBookStores()
        {
            string requestype = "bookStore";
            this.client.endPoint = this.URL + requestype;
            string getrequest = client.makeRequest(1);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            JArray result = jsonResult.resultado;
            string[,] resultado = new string[result.Count, 2];

            for (int i = 0; i < result.Count; i++)
            {
                dynamic libroJson = result.ElementAt(i);
                resultado[i, 0] = libroJson.nombre;
                resultado[i, 1] = libroJson.codigo;
            }

            return resultado;
        }

        public string deletePromotion(string name)
        {
            string requestype = "offer/" + name;
            this.client.endPoint = this.URL + requestype;
            string getrequest = client.makeRequest(4);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;
            return result;

        }

        public string deleteBook(int issn)
        {
            string requestype = "book/" + issn;
            this.client.endPoint = this.URL + requestype;
            string getrequest = client.makeRequest(4);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);

            string result = jsonResult.mensaje;
            return result;

        }



    }
}