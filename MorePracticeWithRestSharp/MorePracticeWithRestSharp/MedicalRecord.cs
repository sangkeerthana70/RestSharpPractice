using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePracticeWithRestSharp
{
    public class MedicalRecord
    {
        public float height { get; set; }
        public float weight { get; set; }
        public float bloodPressure { get; set; }
        public DateTime createDate { get; set; }

        public void AboutMe()
        {
            Console.WriteLine("My height is " + height + " My weight is " + weight + " My blood pressure is " + bloodPressure);

            
        }
    }

    
}
