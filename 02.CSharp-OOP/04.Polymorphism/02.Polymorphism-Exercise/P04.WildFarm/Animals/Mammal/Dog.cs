using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double DogModifier = 0.4;
        private static HashSet<string> DogFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, DogFood, DogModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
