using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }

            for (int i = 0; i < m; i++)
            {
                int input = int.Parse(Console.ReadLine());
                secondSet.Add(input);
            }

            foreach (int number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
