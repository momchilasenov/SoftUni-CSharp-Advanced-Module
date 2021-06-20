using System;
using System.Linq;

namespace P04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] rocks = input.Split(", ").Select(int.Parse).ToArray();

            Lake<int> lake = new Lake<int>(rocks);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
