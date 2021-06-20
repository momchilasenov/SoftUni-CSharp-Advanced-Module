using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;
        private const int MinToppings = 0;
        private const int MaxToppings = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            set => this.dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
            }

            this.toppings.Add(topping);
        }


        public double TotalCalories => this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());

    }
}
