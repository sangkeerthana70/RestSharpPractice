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
            //client.BaseUrl = new Uri("http://twitter.com");
            //client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("/users", Method.GET);
            //request.Resource = "statuses/friends_timeline.xml";

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("Response.Content: " + content);
                

        }
    }
}
