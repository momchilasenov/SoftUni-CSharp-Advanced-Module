using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            //Predicate to check if first letter in a word is uppercase
            Func<string, bool> condition = word => Char.IsUpper(word[0]); //OR
            //Func<string, bool> condition = word => word[0] == word.ToUpper()[0];

            words = words.Where(condition).ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

        }

    }
}
