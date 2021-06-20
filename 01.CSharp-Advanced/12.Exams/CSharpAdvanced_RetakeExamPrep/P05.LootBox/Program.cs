using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> first = new Queue<int>(firstArray);
            Stack<int> second = new Stack<int>(secondArray);

            int claimedItems = 0;

            while (first.Count > 0 && second.Count > 0)
            {
                int currentFirst = first.Peek();
                int currentSecond = second.Peek();
                int sum = currentFirst + currentSecond;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    second.Pop();
                    first.Enqueue(currentSecond);
                }

            }

            string result = first.Count == 0
                ? "First lootbox is empty"
                : "Second lootbox is empty";


            string lootResult = claimedItems >= 100
                ? $"Your loot was epic! Value: {claimedItems}"
                : $"Your loot was poor... Value: {claimedItems}";

            Console.WriteLine(result);
            Console.WriteLine(lootResult);

        }
    }
}
