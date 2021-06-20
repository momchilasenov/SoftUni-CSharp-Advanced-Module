using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string>allowedFoods, double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.AllowedFoods = allowedFoods;
            this.WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }
        
        private double WeightModifier { get; set; }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            //1.validate food
            if (this.AllowedFoods.Contains(food.GetType().Name) == false)
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            //2.increase food eaten
            this.FoodEaten += food.Quantity;
            //3.increase weight
            this.Weight += this.WeightModifier * food.Quantity;
        }
    }
}
