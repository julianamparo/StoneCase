using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StoneCase.Web.Util
{
    public class WebApi
    {
        public static string URI = "https://localhost:44325/api/cobranca/";
        public static string requestGET(string metodo, string parametro)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo +"/"+parametro);
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string requestPOST(string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;            
        }
    }
}