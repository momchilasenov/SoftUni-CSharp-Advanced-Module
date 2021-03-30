using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine()
                .Split()
                .ToArray();

            int passes = int.Parse(Console.ReadLine());
            int counter = 0;
            
            Queue<string> queue = new Queue<string>(names);

            while (queue.Count > 1)
            {
                string kid = queue.Dequeue();
                counter++;
                if (counter == passes)
                {
                    counter = 0;
                    Console.WriteLine($"Removed {kid}");
                }
                else
                {
                    queue.Enqueue(kid);
                }
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");

        }
    }
}
