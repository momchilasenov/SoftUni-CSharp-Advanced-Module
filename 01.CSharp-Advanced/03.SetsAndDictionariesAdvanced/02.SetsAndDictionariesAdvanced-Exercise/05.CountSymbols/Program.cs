using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            for (int i=0; i<input.Length; i++)
            {
                char currentChar = input[i];
                if (!symbols.ContainsKey(currentChar))
                {
                    symbols.Add(currentChar, 1);
                }
                else
                {
                    symbols[currentChar]++;
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}
