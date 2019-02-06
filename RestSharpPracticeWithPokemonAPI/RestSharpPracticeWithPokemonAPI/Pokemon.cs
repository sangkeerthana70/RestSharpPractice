using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpPracticeWithPokemonAPI
{
    public class Pokemon
    {
        public int PokeId { get; set; }
        public string Name { get; set; }
        public string SuperType { get; set; }
        public string SubType { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public string AttacksCost { get; set; }
        public string AttacksName { get; set; }
        public string AttacksText { get; set; }
        public string Weaknesses { get; set; }

    }
}
