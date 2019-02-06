using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //Console.WriteLine("request: " + request);

            // execute the request
            IRestResponse response = client.Execute(request);
            //var contentType = (response.Content).GetType(); // raw content as string

            //Console.WriteLine("Final Content: " + contentType);
            string content = response.Content;
            //Console.WriteLine("Content: " + content);

            JObject apiResult = JObject.Parse(content);
            Console.WriteLine(apiResult);

            Pokemon pokemon = new Pokemon();
            
            pokemon.PokeId = Int32.Parse(apiResult["cards"][0]["id"].ToString());

            Console.WriteLine(pokemon.PokeId);
            /*
            // connect to the db
            var connstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ReastSharpPracticeWithPokemonAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using( SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                SqlCommand insCommand = new SqlCommand("INSERT INTO [dbo].[Pokemon] (PokeId, Name, SuperType, SubType, artist, rarity, AttacksCost, AttacksName, Attackstext, Weaknesses) VALUES (@PokeId, @Name, @SuperType, @SubType, @artist, @rarity, @AttacksCost, @AttacksName, @AttacksText, @Weaknesses)", connection);
                insCommand.Parameters.AddWithValue("@PokeId");
            }
            */
        }
    }
}
