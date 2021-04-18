using System;
using System.Numerics;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger[][] jaggedArray = new BigInteger[n][];

            for (int array = 0; array < n; array++)
            {
                jaggedArray[array] = new BigInteger[array+1];

                for (int element = 0; element < jaggedArray[array].Length; element++)
                {
                    if (jaggedArray[array].Length <= 2)
                    {
                        jaggedArray[array][element] = 1;
                    }
                    else
                    {
                        if (element == 0 || element == jaggedArray[array].Length - 1)
                        {
                            jaggedArray[array][element] = 1;
                        }
                        else
                        {
                            jaggedArray[array][element] = jaggedArray[array - 1][element - 1] + jaggedArray[array - 1][element];
                        }

                    }
                }

            }

            int counter = 0;

            foreach (BigInteger[] array in jaggedArray)
            {
                Console.WriteLine($"{counter++}: {string.Join(' ', array)}");
            }
            
        }
    }
}

