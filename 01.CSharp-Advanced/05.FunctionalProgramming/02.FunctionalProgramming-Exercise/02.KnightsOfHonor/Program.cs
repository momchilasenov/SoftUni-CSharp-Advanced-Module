using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> appendAndPrint = name => Console.WriteLine($"Sir {name}");

            foreach (string name in names)
            {
                appendAndPrint(name);
            }
        
        }
    }
}
