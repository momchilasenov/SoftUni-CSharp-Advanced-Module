using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                value = value.ToLower();
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                Validator.ThrowIfValuesNotPresent(new HashSet<string> { "crispy", "chewy", "homemade" }, value.ToLower(), "Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfWeightNotInRange(nameof(Dough), MinWeight, MaxWeight, value);

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();

            double bakingTechniqueModifier = GetBakingTechniqueModifier();

            double flourCalories = 2 * this.Weight * flourTypeModifier * bakingTechniqueModifier;

            return flourCalories;
        }

        private double GetFlourTypeModifier()
        {
            if (this.FlourType.ToLower() == "white")
            {
                return 1.5;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                return 1.0;
            }

            return 0;
        }

        private double GetBakingTechniqueModifier()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                return 1.0;
            }

            return 0;
        }


    }
}
