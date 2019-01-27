using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            
            //create a new request 
            var request = new RestRequest("/users", Method.GET);

            // execute the request and gives back a response in a Interface
            IRestResponse response = client.Execute(request);
            //brings in the raw content as a string
            var content = response.Content;
            //Console.WriteLine(content);


            //var output = JsonConvert.DeserializeObject(content);
            //Console.WriteLine(output);
            //convert the Json object to an array
            //There is anoher way of converting the deserialized json object into an array to loop through
            JArray a = JArray.Parse(content);
            Console.WriteLine("String a: " + a);

            //use connection string from the 
            var connstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = RestSharpDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                foreach (var item in a)
                {
                    //Console.WriteLine("Items in a: " + item);
                    SqlCommand insCommand = new SqlCommand("INSERT INTO [User] (Id, Name, UserName, Email) VALUES (@Id, @Name, @UserName, @Email)", connection);
                    insCommand.Parameters.AddWithValue("@Id", item["id"].ToObject<int>());
                    insCommand.Parameters.AddWithValue("@Name", item["name"].ToString());
                    insCommand.Parameters.AddWithValue("@UserName", item["username"].ToString());
                    insCommand.Parameters.AddWithValue("@Email", item["email"].ToString());

                    insCommand.ExecuteNonQuery();
                }
                Console.WriteLine("DB updated");
                connection.Close();

                
            }
        }
    }
}
