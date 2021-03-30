using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.FashionBoutique
{
    class Program
    { 
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothesStack = new Stack<int>(numbers);

            int clothesSum = 0;
            int currentSum = 0;

            int racksUsed = 1;


            while (true)
            {
                if (clothesStack.Count > 0)
                {
                    int topElement = clothesStack.Peek();
                    currentSum += topElement;

                    if (rackCapacity > currentSum)
                    {
                        int currentElement = clothesStack.Pop();
                        clothesSum += currentElement;
                    }
                    else if (rackCapacity == currentSum)
                    {
                        clothesStack.Pop();

                        if (clothesStack.Count > 0)
                        {
                            racksUsed++;
                            currentSum = 0;
                        }
                    }
                    else if (currentSum > rackCapacity)
                    {
                        racksUsed++;
                        currentSum = 0;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(racksUsed);

        }
    }
}
