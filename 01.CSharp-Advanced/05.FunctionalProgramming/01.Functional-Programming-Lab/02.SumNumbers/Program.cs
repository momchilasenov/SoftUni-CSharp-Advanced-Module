using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            int[] numberArray = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray(); 

            PrintCountAndSum(numberArray,
                array => array.Length,
                //array => array.Sum() OR
                array =>
                {
                    int totalSum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        totalSum += array[i];
                    }
                    return totalSum;
                });

            MyDelegate someName = x => x * 5;

        }

        public delegate int MyDelegate(int x);

        static void PrintCountAndSum(int[] array, Func<int[], int> getCount, Func<int[], int> getSum)
        {
            Console.WriteLine(getCount(array));
            Console.WriteLine(getSum(array));
        }

    }
}
