using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FlowerWreaths
{
    class Program
    {
        private const int flowersForWreath = 15;

        static void Main(string[] args)
        {
            int wreathCounter = 0;
            int storedFlowers = 0;

            int[] rosesArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] liliesArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> roses = new Queue<int>(rosesArray);
            Stack<int> lilies = new Stack<int>(liliesArray);

            while (roses.Count > 0 && lilies.Count > 0)
            {
                int currentRose = roses.Peek();
                int currentLilie = lilies.Peek();

                if (currentRose + currentLilie > flowersForWreath)
                {
                    while (currentRose + currentLilie > flowersForWreath)
                    {
                        currentLilie -= 2;
                    }
                }

                if (currentRose + currentLilie == flowersForWreath)
                {
                    wreathCounter++;
                    roses.Dequeue();
                    lilies.Pop();
                }

                if (currentRose + currentLilie < flowersForWreath)
                {
                    storedFlowers += currentRose + currentLilie;
                    roses.Dequeue();
                    lilies.Pop();
                }

            }


            //alternative loop
            //while (roses.Count > 0 && lilies.Count > 0)
            //{
            //    int currentRose = roses.Peek();
            //    int currentLilie = lilies.Peek();
                
            //    while (true)
            //    {
            //        int sum = currentRose + currentLilie;

            //        if (sum == 15)
            //        {
            //            wreathCounter++;
            //            break;
            //        }
            //        if (sum < 15)
            //        {
            //            storedFlowers += sum;
            //        }
            //        if (sum > 15)
            //        {
            //            currentLilie -= 2;
            //        }
            //    }
            //}

            int extraWreaths = storedFlowers / flowersForWreath;
            wreathCounter += extraWreaths;

            string result = wreathCounter >= 5
                ? $"You made it, you are going to the competition with {wreathCounter} wreaths!"
                : $"You didn't make it, you need {5 - wreathCounter} wreaths more!";
            Console.WriteLine(result);

        }
    }
}
