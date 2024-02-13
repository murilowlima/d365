using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace D365Assessment.External
{
    public class APIManager
    {
        public string APIUrl { get; set; }

        public APIManager(string apiUrl)
        {
            APIUrl = apiUrl;
        }

        public HttpWebRequest CreateWebRequest()
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(APIUrl);
            webRequest.Method = "GET";
            webRequest.Accept = "*/*";
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            webRequest.ContentType = "application/json";
            webRequest.KeepAlive = false;
            webRequest.UserAgent = "PluginDynamics365";
            return webRequest;
        }

        public object ExecuteRequest<T>(HttpWebRequest request)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            object obj;
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    object objResponse = reader.ReadToEnd();
                    string stringData = objResponse.ToString();
                    using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(stringData)))
                    {
                        var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                        obj = dataContractJsonSerializer.ReadObject(memoryStream);

                    }
                }
            }

            return obj;
        }
    }
}
