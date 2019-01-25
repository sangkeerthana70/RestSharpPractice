using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePracticeWithRestSharp
{
    class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        [JsonProperty("country of birth")]
        public string countryOfBirth { get; set; }
        //public List<MedicalRecord> MRN { get; set; }
    }
}
