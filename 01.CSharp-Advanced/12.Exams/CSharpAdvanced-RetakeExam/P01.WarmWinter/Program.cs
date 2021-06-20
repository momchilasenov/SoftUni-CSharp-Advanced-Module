using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Count != 0 && scarfs.Count != 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                int newSet = 0;

                if (currentHat > currentScarf)
                {
                    newSet = currentHat + currentScarf;
                    sets.Add(newSet);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentScarf > currentHat)
                {
                    hats.Pop();
                    continue;
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    currentHat += 1;
                    hats.Pop();
                    hats.Push(currentHat);
                }
            }

            int maxPriceSet = sets.Max();

            Console.WriteLine($"The most expensive set is: {maxPriceSet}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
