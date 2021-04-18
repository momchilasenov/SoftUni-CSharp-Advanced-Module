using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                      
            for (int i = 0; i < input.Length; i++)
            {
                int occurrences = 1;

                if (dictionary.ContainsKey(input[i]) == false)
                {
                    dictionary.Add(input[i], occurrences++ );
                }
                else
                {
                    dictionary[input[i]] += 1;
                }
            }

            foreach (KeyValuePair<double, int> keys in dictionary)
            {
                Console.WriteLine($"{keys.Key} - {keys.Value} times");
            }
        }
    }
}
