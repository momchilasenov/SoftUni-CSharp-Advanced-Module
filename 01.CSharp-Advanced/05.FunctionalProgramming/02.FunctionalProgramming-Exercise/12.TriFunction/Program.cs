using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int threshold = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> meetsThreshold = (name, number) =>
            { 
                int currentSum = 0;
                foreach (char chr in name)
                {
                    currentSum += chr;
                }
                return currentSum >= number;

                //OR name.Sum(x => x) >= number
            };

            Func<string[], Func<string, int, bool>, bool> getResult = (names, meetsThreshold) =>
            {
                foreach (string name in names)
                {
                    if (meetsThreshold(name, threshold))
                    {
                        Console.WriteLine(name);
                        return true;
                    }

                }
                return false;
            };

            getResult(names, meetsThreshold);

        }
    }
}
