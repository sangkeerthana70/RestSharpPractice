﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
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
            JArray a = JArray.Parse(content);
            Console.WriteLine("String a: " + a);
        
            foreach (var item in a)
            {
                Console.WriteLine("Items in a: " + item);
            }
        }
    }
}