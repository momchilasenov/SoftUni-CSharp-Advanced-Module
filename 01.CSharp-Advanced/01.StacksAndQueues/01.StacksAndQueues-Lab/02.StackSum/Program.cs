using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] numbers = input.Split(' ')
                .Select(int.Parse)
                .ToArray();


            Stack<int> stack = new Stack<int>(numbers);

            string token = Console.ReadLine().ToLower();

            while (token != "end")
            {
                string[] commandsData = token.Split();
                string command = commandsData[0];

                if (command == "add")
                {
                    int firstNumber = int.Parse(commandsData[1]);
                    int secondNumber = int.Parse(commandsData[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int firstNumber = int.Parse(commandsData[1]);
                    if (firstNumber > stack.Count)
                    {
                        token = Console.ReadLine().ToLower();
                        continue;
                    }
                    for (int i = 0; i < firstNumber; i++)
                    {
                        stack.Pop();
                    }
                }

                token = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}
