using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
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
            //this.URL = "mongodb://localhost/TECHealthDB";

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
            string requestType = "book/";
            logIn usuario = new logIn();
            usuario.user = id;
            usuario.password = password;
            string json = JsonConvert.SerializeObject(usuario);

            this.URL = this.URL + requestType + "/" + json;
            this.client.endPoint = this.URL;

            

            

            string getrequest = client.makeRequest(1);
            Console.WriteLine("Before task");
            //string getrequest = client.GetRequestAsync(json).Result;
            Console.WriteLine("Task ended");
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);
            idUsuario = jsonResult.id;
            tipoUsuario = jsonResult.tipo;

            // Llenado del array
            result[0] = idUsuario;
            result[1] = tipoUsuario;

            // Resultado de la consulta
            return result;
        }


    }
}