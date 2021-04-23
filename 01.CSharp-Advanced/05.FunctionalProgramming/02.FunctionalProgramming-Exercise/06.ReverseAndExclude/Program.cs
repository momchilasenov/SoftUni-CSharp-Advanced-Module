using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> DividesByN = number => number % divisor == 0;

            numbers.Reverse();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (DividesByN(numbers[i]))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
