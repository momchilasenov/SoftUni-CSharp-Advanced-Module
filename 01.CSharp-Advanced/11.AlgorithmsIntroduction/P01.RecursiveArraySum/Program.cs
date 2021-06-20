using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            long sum = Sum(numbers, 0);

            Console.WriteLine(sum);

        }

        public static long Sum(int[] numbers, int startIndex)
        {
            if (startIndex == numbers.Length - 1) //base case
            {
                return numbers[startIndex];
            }

            return numbers[startIndex] + Sum(numbers, startIndex + 1);
        }
    }
}
