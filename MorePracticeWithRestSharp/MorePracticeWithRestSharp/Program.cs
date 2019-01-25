using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePracticeWithRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            string ApiResult = @"
            {
            'name' : 'Senthil',
            'age' : 41,
            'gender' : 'Male',
            'country of birth': 'India',
            'Medical Records' :
            [
            {
            'height' : 165,
            'weight' : 134.4,
            'blood pressure' : 120,
            'date' : '2018-01-01'
            }
            ,
            {
            'height' : 165,
            'weight' : 130.4,
            'blood pressure' : 120,
            'date' : '2017-01-01'
            }
            ]
            }
            ";
                Console.WriteLine(ApiResult);
            /*
            Method -1 JsonConvert will convert the string into a  Csharp Person object and map the values to each properties
            Person p = JsonConvert.DeserializeObject<Person>(ApiResult);

            Console.WriteLine(p.name);
            Console.WriteLine(p.age);
            Console.WriteLine(p.gender);            
            Console.WriteLine(p.countryOfBirth);
            */

            // Method-2
            // parse incoming Json into Csharp object 
            JObject person  = JObject.Parse(ApiResult);

        }
        
    }
    
}
