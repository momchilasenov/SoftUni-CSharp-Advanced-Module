using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] {"->", ","},StringSplitOptions.None)
                    .ToArray();

                string color = input[0].Trim();

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string currentClothing = input[j].Trim();

                    if (!clothes[color].ContainsKey(currentClothing))
                    {
                        clothes[color].Add(currentClothing, 1);
                    }
                    else
                    {
                        clothes[color][currentClothing]++;
                    }
                }
            }

            string[] token = Console.ReadLine().Split();
            string colorToFind = token[0];
            string clothingToFind = token[1];

            foreach (var element in clothes)
            {
                Console.WriteLine($"{element.Key} clothes:");

                foreach (var subElement in element.Value)
                {
                    if(element.Key == colorToFind && subElement.Key == clothingToFind)
                    {
                        Console.WriteLine($"* {subElement.Key} - {subElement.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {subElement.Key} - {subElement.Value}");
                    }
                    
                }
            }
        }
    }
}
