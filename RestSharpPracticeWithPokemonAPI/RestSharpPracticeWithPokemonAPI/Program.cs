using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpPracticeWithPokemonAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.pokemontcg.io/");

            // create a new request
            var request = new RestRequest("v1/cards?name=blastoise|charizard", Method.GET);
            Console.WriteLine("request: " + request);

            // execute the request
            IRestResponse response = client.Execute(request);
            var contentType = (response.Content).GetType(); // raw content as string

            Console.WriteLine("Final Content: " + contentType);
            string content = response.Content;
            Console.WriteLine("Content: " + content);

        }
    }
}
