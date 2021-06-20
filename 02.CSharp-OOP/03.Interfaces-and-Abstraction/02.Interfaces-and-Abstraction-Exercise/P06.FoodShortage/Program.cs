using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthdate = data[3];
                    buyers.Add(name, new Citizen(name, age, birthdate, id));
                }
                else if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];
                    buyers.Add(name, new Rebel(name, age, group));
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (buyers.ContainsKey(input))
                {
                    buyers[input].BuyFood();
                }

            }

            int sum = 0;

            foreach (var buyer in buyers)
            {
                sum += buyer.Value.Food;
            }

            Console.WriteLine(sum);

        }
    }
}

