using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpPracticeWithPokemonAPI
{
    public class Pokemon
    {
        public string PokeId { get; set; }
        public string Name { get; set; }
        public string SuperType { get; set; }
        public string SubType { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }        
        public string Attack1Name { get; set; }
        public string Attack1Text { get; set; }
        public string Attack2Name { get; set; }
        public string Attack2Text { get; set; }
        public string WeaknessType { get; set; }

        public Pokemon()
        {
            Name = "";
            SuperType = "";
            SubType = "";
            artist = "";
            rarity = "";
            Attack1Name = "";
            Attack1Text = "";
            Attack2Name = "";
            Attack2Text = "";
            WeaknessType = "";

        }

        public void About()
        {
            Console.WriteLine("My Pokemon Id : " + this.PokeId);
            Console.WriteLine("My name is: " + Name);
            Console.WriteLine("I am a " + SuperType + SubType + " type");
            Console.WriteLine("My artist is: " + artist);
            Console.WriteLine("My rarity is: " + rarity);
            Console.WriteLine("My attackName is : " + Attack1Name);
            Console.WriteLine("My attack description : " + Attack1Text);
            Console.WriteLine("My attackName is : " + Attack2Name);
            Console.WriteLine("My attack description : " + Attack2Text);
            Console.WriteLine("My Weakness : " + WeaknessType);
        }
    }
    

}

