using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split();

            Stack<string> halls = new Stack<string>();
            Stack<int> guests = new Stack<int>();
            var hallDictionary = new Dictionary<string, List<int>>();

            //Stack
            for (int i = 0; i < input.Length; i++)
            {
                bool isNumeric = int.TryParse(input[i], out int n);

                if (isNumeric)
                {
                    guests.Push(int.Parse(input[i]));
                }
                else
                {
                    halls.Push(input[i]);
                }
            }

            while (guests.Count > 0)
            {
                string currentHall = halls.Peek();
                int currentGuest = guests.Peek();

                if (currentGuest > maxCapacity)
                {
                    guests.Pop();
                    continue;
                }

                if (!hallDictionary.ContainsKey(currentHall))
                {
                    hallDictionary.Add(currentHall, new List<int>());
                }

                if (hallDictionary[currentHall].Sum() + currentGuest <= maxCapacity)
                {
                    hallDictionary[currentHall].Add(currentGuest);
                    guests.Pop();

                    if (hallDictionary[currentHall].Sum() == maxCapacity)
                    {
                        halls.Pop();
                        Console.WriteLine($"{currentHall} -> " +
                            $"{string.Join(", ", hallDictionary[currentHall])}");
                    }
                }
                else if (hallDictionary[currentHall].Sum()+currentGuest > maxCapacity 
                    && halls.Count>1) //if there is another hall for the guests
                {
                    halls.Pop();
                    Console.WriteLine($"{currentHall} -> " +
                        $"{string.Join(", ", hallDictionary[currentHall])}");
                }
                else if (hallDictionary[currentHall].Sum() + currentGuest > maxCapacity
                    && halls.Count <= 1) //if there are no other halls to go to
                {
                    guests.Pop();
                }
            }
        }
    }
}
