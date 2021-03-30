using System;
using System.Linq;
using System.Collections.Generic;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Enqueue(input[i]);
            }

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    result += number + ", ";
                }
            }
            Console.WriteLine(result.TrimEnd(new char[] { ',', ' ' }));



        }
    }
}
