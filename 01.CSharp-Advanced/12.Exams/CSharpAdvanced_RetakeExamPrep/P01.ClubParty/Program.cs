using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallMaximumCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split();

            Stack<char> hallStack = new Stack<char>();
            Stack<int> peopleStack = new Stack<int>();

            Dictionary<char, List<int>> hallData = new Dictionary<char, List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                bool isNumber = int.TryParse(input[i], out int result);

                if (isNumber)
                {
                    peopleStack.Push(result);
                }
                else
                {
                    hallStack.Push(char.Parse(input[i]));
                }
            }

            while (hallStack.Count != 0 && peopleStack.Count != 0)
            {
                char currentHall = hallStack.Peek();
                int currentSum = 0;

                while (currentSum <= hallMaximumCapacity)
                {
                    if (hallStack.Count == 0 || peopleStack.Count == 0)
                    {
                        break;
                    }

                    int currentPerson = peopleStack.Peek();
                    currentSum += currentPerson;

                    if (currentSum > hallMaximumCapacity)
                    {
                        Console.WriteLine($"{currentHall} -> {string.Join(", ", hallData[currentHall])}");
                        hallStack.Pop();
                        break;
                    }

                    if (hallData.ContainsKey(currentHall) == false)
                    {
                        hallData.Add(currentHall, new List<int>());
                        hallData[currentHall].Add(currentPerson);
                    }
                    else
                    {
                        hallData[currentHall].Add(currentPerson);
                    }

                    peopleStack.Pop();
                }
            }
        }
    }
}

