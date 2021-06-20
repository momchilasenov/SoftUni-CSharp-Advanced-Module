using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace P01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bread = 25;
            const int cake = 50;
            const int pastry = 75;
            const int fruitPie = 100;

            int[] liquidsData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] ingredientsData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(liquidsData);
            Stack<int> ingredients = new Stack<int>(ingredientsData);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int pieCount = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquidElement = liquids.Peek();
                int ingredientElement = ingredients.Peek();

                if (liquidElement + ingredientElement == bread)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    breadCount++;
                }
                else if (liquidElement + ingredientElement == cake)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cakeCount++;
                }
                else if (liquidElement + ingredientElement == pastry)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    pastryCount++;
                }
                else if (liquidElement + ingredientElement == fruitPie)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    pieCount++;
                }
                else
                {
                    liquids.Dequeue();
                    int temp = ingredientElement + 3;
                    ingredients.Pop();
                    ingredients.Push(temp);
                }
            }

            bool cookedAll = breadCount > 0 && cakeCount > 0 && pastryCount > 0 && pieCount > 0;

            if (cookedAll)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bread: {breadCount}");
            sb.AppendLine($"Cake: {cakeCount}");
            sb.AppendLine($"Fruit Pie: {pieCount}");
            sb.AppendLine($"Pastry: {pastryCount}");

            Console.WriteLine(sb.ToString().TrimEnd());

        }
    }
}
