using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = numbers[0];
            int elementsToDequeue = numbers[1];
            int elementToFind = numbers[2];

            

            int smallestNumber = int.MaxValue;

            int[] numbersToAdd = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            Queue<int> numbersQueue = new Queue<int>(numbersToAdd);

            for (int i = 0; i < elementsToDequeue; i++)
            {
                numbersQueue.Dequeue();
            }

            if (elementsToDequeue >= elementsToEnqueue)
            {
                Console.WriteLine(0);
                return;
            }

            if (numbersQueue.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (int number in numbersQueue)
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
