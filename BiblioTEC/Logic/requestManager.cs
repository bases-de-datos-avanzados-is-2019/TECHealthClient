using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

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
            this.IP = "";
            this.PORT = "";
            // Se arma el URL
            this.URL = "http://" + IP + ":" + PORT + "";

        }

        /*
         *  LogIn del usuario
         */
        public string[] logIn(string id, string password)
        {
            // string de respuesta
            string idUsuario = "";
            string tipoUsuario = "";
            string[] result = new string[2];

            // Consulta
            string requestType = "loginEstudiante/";
            this.URL = this.URL + requestType + id + "/" + password;
            this.client.endPoint = this.URL;
            string getrequest = client.makeRequest(1);
            getrequest = getrequest.Replace("\"", "'");
            dynamic jsonResult = JsonConvert.DeserializeObject(getrequest);
            idUsuario = jsonResult[0].id;
            tipoUsuario = jsonResult[0].tipo;

            // Llenado del array
            result[0] = idUsuario;
            result[1] = tipoUsuario;

            // Resultado de la consulta
            return result;
        }


    }
}