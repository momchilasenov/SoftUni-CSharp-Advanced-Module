using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = numbers[0];
            int elementsToPop = numbers[1];
            int elementToFind = numbers[2];

            int[] numbersToPush = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numberStack = new Stack<int>(numbersToPush);

            int smallestNumber = int.MaxValue;

            if (elementsToPop >= elementsToPush)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                numberStack.Pop();
            }

            if (numberStack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (int number in numberStack)
                {
                    if (number < smallestNumber)
                    {
                        smallestNumber = number;
                    }
                }
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
