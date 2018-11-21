using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace APIRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            

            var request = new RestRequest("/users", Method.GET);
            //request.Resource = "statuses/friends_timeline.xml";

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //returns raw content as string
            Console.WriteLine("Response.Content: " + content);

            string output = JsonConvert.SerializeObject(content);
            Console.WriteLine(output);

            //Content deserializedContent = JsonConvert.DeserializeObject<Content>(output);
            //Console.WriteLine(deserializedContent);
            var jsonArray = JArray.FromObject(JsonConvert.DeserializeObject(content));
            Console.WriteLine(jsonArray);

        }
    }
}
