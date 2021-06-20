using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            const int threshold = 100;

            int[] firstData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> firstBox = new Queue<int>(firstData);

            int[] secondData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> secondBox = new Stack<int>(secondData);

            int claimedItems = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currentFirstItem = firstBox.Peek();
                int currentSecondItem = secondBox.Peek();

                int currentSum = currentFirstItem + currentSecondItem;

                if (currentSum % 2 == 0)
                {
                    claimedItems += currentSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(currentSecondItem);
                }

            }

            string emptyBox = firstBox.Count == 0 
                ? "First lootbox is empty" 
                : "Second lootbox is empty";

            Console.WriteLine(emptyBox);

            string lootQuality = claimedItems >= threshold
                ? $"Your loot was epic! Value: {claimedItems}"
                : $"Your loot was poor... Value: {claimedItems}";

            Console.WriteLine(lootQuality);
        }
    }
}
