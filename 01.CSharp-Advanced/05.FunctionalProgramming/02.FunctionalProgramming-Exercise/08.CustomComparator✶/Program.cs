using System;
using System.Linq;

namespace _08.CustomComparator_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> customComparator = (a, b) =>
            {
                //Insertion sort algorithm
                if (a % 2 == 0 && b % 2 == 0) //puts all even nums on the left
                {
                    // 2 4
                    if (a > b)
                    {
                        return 1;
                    }

                    if (a < b)
                    {
                        return -1;
                    }

                    return 0;
                }
                if (a % 2 != 0 && b % 2 != 0) //puts all odd nums on the right 
                {
                    // 1 3
                    if (a > b)
                    {
                        return 1;
                    }

                    if (a < b)
                    {
                        return -1;
                    }

                    return 0;
                }

                if (a % 2 == 0)
                {
                    return -1;
                }

                if (a % 2 != 0)
                {
                    return 1;
                }

                return 0;

            };

            Array.Sort(numbers, new Comparison<int>(customComparator));

            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
