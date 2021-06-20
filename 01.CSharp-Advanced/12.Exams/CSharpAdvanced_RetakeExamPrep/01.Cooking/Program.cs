using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        private const int Bread = 25;
        private const int Cake = 50;
        private const int Pastry = 75;
        private const int FruitPie = 100;

        static void Main(string[] args)
        {
            int[] liquidsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> liquids = new Queue<int>(liquidsArray);

            int[] ingredientsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> ingredients = new Stack<int>(ingredientsArray);

            int[] itemArray = { Bread, Cake, FruitPie, Pastry };

            Dictionary<string, int> items = new Dictionary<string, int>();
            items.Add("Bread", 0);
            items.Add("Cake", 0);
            items.Add("Pastry", 0);
            items.Add("Fruit Pie", 0);

            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();

                int sum = currentLiquid + currentIngredient;

                if (itemArray.Contains(sum))
                {
                    liquids.Dequeue();
                    ingredients.Pop();

                    if (sum == Bread)
                    {
                        items["Bread"]++;
                    }
                    else if (sum == Cake)
                    {
                        items["Cake"]++;
                    }
                    else if (sum == Pastry)
                    {
                        items["Pastry"]++;
                    }
                    else if (sum == FruitPie)
                    {
                        items["Fruit Pie"]++;
                    }
                }
                else
                {
                    liquids.Dequeue();
                    currentIngredient += 3;

                    ingredients.Pop();
                    ingredients.Push(currentIngredient);
                }
            }

            string allItemsCollected = items.Any(i => i.Value == 0)
                ? "Ugh, what a pity! You didn't have enough materials to cook everything."
                : "Wohoo! You succeeded in cooking all the food!";

            string liquidsString = liquids.Count == 0
                ? "Liquids left: none"
                : $"Liquids left: {string.Join(", ", liquids)}";

            string ingredientsString = ingredients.Count == 0
                ? "Ingredients left: none"
                : $"Ingredients left: {string.Join(", ", ingredients)}";

            Console.WriteLine(allItemsCollected);
            Console.WriteLine(liquidsString);
            Console.WriteLine(ingredientsString);

            Console.WriteLine($"Bread: {items["Bread"]}");
            Console.WriteLine($"Cake: {items["Cake"]}");
            Console.WriteLine($"Fruit Pie: {items["Fruit Pie"]}");
            Console.WriteLine($"Pastry: {items["Pastry"]}");


        }
    }
}
