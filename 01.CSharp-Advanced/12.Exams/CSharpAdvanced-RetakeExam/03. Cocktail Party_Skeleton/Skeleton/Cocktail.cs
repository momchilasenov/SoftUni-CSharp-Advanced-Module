using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.ingredients = new List<Ingredient>();

            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;

        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => ingredients.Count;

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.ingredients.Select(i => i.Alcohol).Sum();

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Contains(ingredient))
            {
                if (this.Count < this.Capacity)
                {
                    int totalAlcohol = ingredients.Select(i => i.Alcohol).Sum();

                    if (totalAlcohol + ingredient.Alcohol <= MaxAlcoholLevel)
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(i => i.Name == name);

            return ingredients.Remove(ingredient);

            //if (ingredient == null)
            //{
            //    return false;
            //}

            //ingredients.Remove(ingredient);
            //return true;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient == null)
            {
                return null;
            }

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int maxAlcohol = int.MinValue;

            foreach(var ingredientValue in ingredients)
            {
                if (ingredientValue.Alcohol > maxAlcohol)
                {
                    maxAlcohol = ingredientValue.Alcohol;
                }
            }

            Ingredient ingredient = ingredients.FirstOrDefault(i => i.Alcohol == maxAlcohol);

            return ingredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach(var ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
