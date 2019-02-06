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
            var cards = apiResult["cards"];
            Console.WriteLine(cards.GetType());
            //Console.WriteLine(cards);


            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (var card in cards)
            {
                Pokemon pokemon = new Pokemon();
                pokemon.PokeId = card["id"].ToString();
                pokemon.Name = card["name"].ToString();
                pokemon.SuperType = card["supertype"].ToString();
                pokemon.SubType = card["subtype"].ToString();
                pokemon.artist = card["artist"].ToString();

                if (card["rarity"] != null)
                {
                    pokemon.rarity = card["rarity"].ToString();
                }

                int attackCount = 0;
                var attacks = card["attacks"];
                if(attacks != null)
                {
                    attackCount = attacks.Count();
                    Console.WriteLine(attackCount);
                }
                
                if(attackCount >= 1)
                {
                    if (card["attacks"][0]["name"] != null)
                    {
                        pokemon.Attack1Name = card["attacks"][0]["name"].ToString();
                    }
                    if (card["attacks"][0]["text"] != null)
                    {
                        pokemon.Attack1Text = card["attacks"][0]["text"].ToString();
                    }

                }
                if (attackCount >= 2)
                {
                    if (card["attacks"][1]["name"] != null)
                    {
                        pokemon.Attack1Name = card["attacks"][1]["name"].ToString();
                    }
                    if (card["attacks"][1]["text"] != null)
                    {
                        pokemon.Attack1Text = card["attacks"][1]["text"].ToString();
                    }

                }

                if (card["weaknesses"] != null)
                {
                    pokemon.WeaknessType = card["weaknesses"][0]["type"].ToString();
                }

                pokemon.About();
                pokemons.Add(pokemon);
            }

            
            // connect to the db
            var connstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ReastSharpPracticeWithPokemonAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using( SqlConnection connection = new SqlConnection(connstring))           
            {
                connection.Open();
                foreach (var pokemon in pokemons)
                {
                    SqlCommand insCommand = new SqlCommand("INSERT INTO [dbo].[Pokemon] (PokeId, Name, SuperType, SubType, artist, rarity, Attack1Name, Attack1Text, Attack2Name, Attack2Text, WeaknessType) VALUES (@PokeId, @Name, @SuperType, @SubType, @artist, @rarity, @Attack1Name, @Attack1Text, @Attack2Name, @Attack2Text, @WeaknessType)", connection);
                    insCommand.Parameters.AddWithValue("@PokeId", pokemon.PokeId);
                    insCommand.Parameters.AddWithValue("@Name", pokemon.Name);
                    insCommand.Parameters.AddWithValue("@SuperType", pokemon.SuperType);
                    insCommand.Parameters.AddWithValue("@SubType", pokemon.SubType);
                    insCommand.Parameters.AddWithValue("@artist", pokemon.artist);
                    insCommand.Parameters.AddWithValue("@rarity", pokemon.rarity);
                    insCommand.Parameters.AddWithValue("@Attack1Name", pokemon.Attack1Name);
                    insCommand.Parameters.AddWithValue("@Attack1Text", pokemon.Attack1Text);
                    insCommand.Parameters.AddWithValue("@Attack2Name", pokemon.Attack2Name); 
                    insCommand.Parameters.AddWithValue("@Attack2Text", pokemon.Attack2Text);
                    insCommand.Parameters.AddWithValue("@WeaknessType", pokemon.WeaknessType);

                    insCommand.ExecuteNonQuery();
                }
                
                Console.WriteLine("DB updated");
                connection.Close();

            }
            
        }

    }
}
