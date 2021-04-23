using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] evenNumbers = Console.ReadLine()
                .Split(", ")
                .Select(x => int.Parse(x))
                .Where(x =>
                {
                    return x % 2 == 0;
                })
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
