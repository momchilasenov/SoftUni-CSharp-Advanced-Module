using System;
using System.Collections.Generic;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofQueries = int.Parse(Console.ReadLine());

            Stack<int> numbersStack = new Stack<int>();

            int maxElement = int.MinValue;
            int minElement = int.MaxValue;

            for (int i = 0; i < numberofQueries; i++)
            {
                string[] querie = Console.ReadLine().Split();

                if (querie[0] == "1")
                {
                    int elementToPush = int.Parse(querie[1].ToString());
                    numbersStack.Push(elementToPush);
                }
                else if (querie[0] == "2")
                {
                    if (numbersStack.Count > 0)
                    {
                        numbersStack.Pop();
                    }
                }
                else if (querie[0] == "3")
                {
                    if (numbersStack.Count > 0)
                    {
                        foreach (int number in numbersStack)
                        {
                            if (number > maxElement)
                            {
                                maxElement = number;
                            }
                        }
                        Console.WriteLine(maxElement);
                    }
                }
                else if (querie[0] == "4")
                {
                    if (numbersStack.Count > 0)
                    {
                        foreach (int number in numbersStack)
                        {
                            if (number < minElement)
                            {
                                minElement = number;
                            }
                        }
                        Console.WriteLine(minElement);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbersStack));
        }
    }
}
