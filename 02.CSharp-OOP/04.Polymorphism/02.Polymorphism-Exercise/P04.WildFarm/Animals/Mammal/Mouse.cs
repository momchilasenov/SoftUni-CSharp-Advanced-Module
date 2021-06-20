using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammal
{
    public class Mouse : Mammal
    {
        private const double MouseModifier = 0.10;
        private static HashSet<string> MouseFoods = new HashSet<string>()
        {
            nameof(Fruit),
            nameof(Vegetable)
        };

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, MouseFoods, MouseModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
