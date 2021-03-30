using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());

            int[] orderQuantities = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int biggestOrder = int.MinValue;

            Queue<int> ordersQueue = new Queue<int>(orderQuantities);

            foreach (int order in ordersQueue)
            {
                if (order > biggestOrder)
                {
                    biggestOrder = order;
                }
            }
            Console.WriteLine(biggestOrder);

            while (ordersQueue.Count > 0 && totalFood >= 0)
            {
                int orderToRemove = ordersQueue.Peek();

                if (totalFood >= orderToRemove)
                {
                    ordersQueue.Dequeue();
                    totalFood -= orderToRemove;
                }
                else
                {
                    totalFood -= orderToRemove;
                    break;
                }
            }

            if (totalFood >= 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', ordersQueue)}");
            }


        }
    }
}
