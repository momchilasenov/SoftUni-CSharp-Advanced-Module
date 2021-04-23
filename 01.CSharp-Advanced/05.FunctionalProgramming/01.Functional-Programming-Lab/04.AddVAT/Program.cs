using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, decimal> decimalParser = x => decimal.Parse(x);

            decimal[] prices = Console.ReadLine()
                .Split(", ")
                .Select(decimalParser)
                .Select(price=>)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }

        }

        //how Select() works
        static decimal[] Select(decimal[] array, Func<decimal, decimal> modifier)
        {
            decimal[] newArray = new decimal[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = modifier(array[i]); //calling the method modifier
            }

            return newArray;
        }


    }
}
