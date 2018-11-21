using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                

        }
    }
}
