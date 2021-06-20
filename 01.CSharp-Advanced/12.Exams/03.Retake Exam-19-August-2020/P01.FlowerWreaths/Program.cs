using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            const int wreath = 15;
            const int wreathsNeeded = 5;
            int wreathCounter = 0;
            int storedFlowers = 0;

            int[] liliesData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(liliesData);

            int[] rosesData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> roses = new Queue<int>(rosesData);

            while (true)
            {
                if (lilies.Count == 0 || roses.Count == 0)
                {
                    break;
                }

                int currentLilie = lilies.Peek();
                int currentRose = roses.Peek();
                bool canMakeWreath = currentLilie + currentRose == wreath;

                if (canMakeWreath)
                {
                    wreathCounter = CreateWreath(wreathCounter, lilies, roses);
                }
                else if (currentLilie + currentRose > wreath)
                {
                    while (currentLilie + currentRose > wreath)
                    {
                        currentLilie -= 2;
                        if (currentLilie + currentRose == wreath)
                        {
                            wreathCounter = CreateWreath(wreathCounter, lilies, roses);
                        }
                        else if (currentLilie + currentRose < wreath)
                        {
                            storedFlowers += currentLilie + currentRose;
                            lilies.Pop();
                            roses.Dequeue();
                        }
                    }
                }
                else if (currentLilie + currentRose < wreath)
                {
                    storedFlowers += currentLilie + currentRose;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            int extraWreaths = storedFlowers / 15;
            wreathCounter += extraWreaths;

            if (wreathCounter >= wreathsNeeded)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCounter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {wreathsNeeded - wreathCounter} wreaths more!");
            }

        }

        private static int CreateWreath(int wreathCounter, Stack<int> lilies, Queue<int> roses)
        {
            wreathCounter++;
            lilies.Pop();
            roses.Dequeue();
            return wreathCounter;
        }
    }
}
