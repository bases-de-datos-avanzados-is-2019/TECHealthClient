using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTEC.Logic
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class restClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public string result { get; set; }
        public restClient()
        {
            endPoint = string.Empty;
            //  httpMethod = httpVerb.GET;              
        }
        public string makeRequest(int typeRequest)

        {
            switch (typeRequest)
            {
                case 1:
                    httpMethod = httpVerb.GET;
                    break;
                case 2:
                    httpMethod = httpVerb.POST;
                    break;
                case 3:
                    httpMethod = httpVerb.PUT;
                    break;
                case 4:
                    httpMethod = httpVerb.DELETE;
                    break;
            }
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();

            /*
            request.ContentType = "application/json";
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {

                writer.Write(body);
                writer.Flush();
                writer.Close();
                }
             */
        

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            return strResponseValue;
        }

        public async Task<string> GetRequestAsync(string json)
        {
           

            using (HttpClient client = new HttpClient())
            {
                HttpMethod reqMethod = new HttpMethod("GET");
                HttpRequestMessage message = new HttpRequestMessage(reqMethod,endPoint);
                message.Content = new StringContent(json, Encoding.UTF8, "application/json");
                

                using (HttpResponseMessage response = await client.SendAsync(message))
                {
                  
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                       
                       
                        return myContent;
                    }
                }
            }

           
        }
    }
}