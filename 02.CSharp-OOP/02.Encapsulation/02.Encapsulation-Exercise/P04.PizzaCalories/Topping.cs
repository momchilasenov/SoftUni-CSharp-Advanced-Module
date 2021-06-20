using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfValuesNotPresent(
                    new HashSet<string> { "meat", "veggies", "cheese", "sauce" },
                    value.ToLower(),
                    $"Cannot place { value} on top of your pizza.");

                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfWeightNotInRange(this.Name, MinWeight, MaxWeight, value);

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double toppingModifier = GetToppingModifier();

            return this.Weight * 2 * toppingModifier;
        }

        private double GetToppingModifier()
        {
            string topping = this.Name.ToLower();

            if (topping == "meat")
            {
                return 1.2;
            }
            if (topping == "veggies")
            {
                return 0.8;
            }
            if (topping == "cheese")
            {
                return 1.1;
            }
            if (topping == "sauce")
            {
                return 0.9;
            }

            return 0;
        }
    }
}
