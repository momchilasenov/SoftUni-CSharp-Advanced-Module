using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split().ToArray();

            Func<string, bool> WordLength = name => name.Length <= length;

            foreach (string name in names)
            {
                if (WordLength(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
