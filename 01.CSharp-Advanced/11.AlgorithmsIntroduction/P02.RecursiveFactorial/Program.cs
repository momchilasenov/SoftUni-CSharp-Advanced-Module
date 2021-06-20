using System;

namespace P02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int factorialSum = GetFactorial(n);

            Console.WriteLine(factorialSum);
        }

        public static int GetFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * GetFactorial(n - 1);
        }
    }
}
