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
            'blood pressure' : 117,
            'date' : '2017-01-01'
            }
            ]
            }
            ";
            // Method-2
            // parse incoming Json into a  Csharp object without any class needed
            JObject jAPIResult  = JObject.Parse(ApiResult);

            Person person = new Person();
            // parse the Object's property into string
            person.name = jAPIResult["name"].ToString();
            person.age = Int32.Parse(jAPIResult["age"].ToString());
            person.countryOfBirth = jAPIResult["country of birth"].ToString();
            person.gender = jAPIResult["gender"].ToString();

            
            List<MedicalRecord> mr = new List<MedicalRecord>();
            var mrn = jAPIResult["Medical Records"];
            Console.WriteLine("mrn: " + mrn);
            string tempDate;
 

            foreach (var record in mrn)
            {
                
                MedicalRecord medicalrecord = new MedicalRecord();
                medicalrecord.height = float.Parse(record["height"].ToString());
                medicalrecord.weight = float.Parse(record["weight"].ToString());
                medicalrecord.bloodPressure = float.Parse(record["blood pressure"].ToString());
                tempDate = record["date"].ToString();
                // parse date which is a string to DateTime data type
                DateTime mrdate =
                     new DateTime(
                     Int32.Parse(tempDate.Substring(0, 4)),
                     Int32.Parse(tempDate.Substring(5, 2)),
                     Int32.Parse(tempDate.Substring(8, 2))
                     );

                medicalrecord.createDate = mrdate;

                mr.Add(medicalrecord);
            }

            person.MRN = mr;
            Console.WriteLine(person.AboutMe());
            person.MRN[0].AboutMe();
            person.MRN[1].AboutMe();

        }

    }
    
}
