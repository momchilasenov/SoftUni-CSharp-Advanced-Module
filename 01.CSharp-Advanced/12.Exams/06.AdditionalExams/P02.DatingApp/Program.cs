using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] maleData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] femaleData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(maleData);
            Queue<int> females = new Queue<int>(femaleData);

            int matchesCount = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Peek();
                int currentFemale = females.Peek();

                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                else if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }
                else if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }

                if (currentMale == currentFemale)
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    currentMale -= 2;
                    males.Pop();
                    males.Push(currentMale);
                }


            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}
