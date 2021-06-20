using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double HenWeight = 0.35;
        private static HashSet<string> HenFood = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, HenFood, HenWeight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
