using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());

            int[] numbers = Enumerable.Range(1, rangeEnd).ToArray();

            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> uniqueDividers = new List<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (!uniqueDividers.Contains(sequence[i]))
                {
                    uniqueDividers.Add(sequence[i]);
                }
            }

            bool canDivide = false;

            Func<int, int, bool> IsDivisible = (number, divider) => number % divider == 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                foreach (int divider in uniqueDividers)
                {
                    if (IsDivisible(numbers[i], divider))
                    {
                        canDivide = true;
                        continue;
                    }
                    else
                    {
                        canDivide = false;
                        break;
                    }
                }

                if (canDivide)
                {
                    Console.Write(numbers[i] + " ");
                }

            }

        }
    }
}
