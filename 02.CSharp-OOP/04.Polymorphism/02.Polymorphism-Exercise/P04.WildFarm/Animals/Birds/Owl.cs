using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double OwlWeight = 0.25;
        private static HashSet<string> OwlFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, OwlFood, OwlWeight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
