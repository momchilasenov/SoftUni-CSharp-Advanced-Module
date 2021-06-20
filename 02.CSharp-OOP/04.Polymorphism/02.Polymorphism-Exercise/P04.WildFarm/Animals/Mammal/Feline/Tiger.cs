using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double TigerModifier = 1.00;
        private static HashSet<string> TigerFood = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, TigerFood, TigerModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
