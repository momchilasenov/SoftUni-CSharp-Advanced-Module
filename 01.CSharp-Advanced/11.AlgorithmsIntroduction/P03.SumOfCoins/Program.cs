using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.SumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine().Substring(7);
            int[] coinArray = coins.Split(", ").Select(int.Parse).ToArray();

            string sum = Console.ReadLine().Substring(5);
            int desiredSum = int.Parse(sum); //923

            Dictionary<int, int> coinDictionary = new Dictionary<int, int>();

            //Coins: 1, 2, 5, 10, 20, 50
            //Sum: 923

            //923 = 18 * 50 + 1*20+

            int currentSum = 0;

            coinArray = coinArray.OrderByDescending(c => c).ToArray();

            for (int i = 0; i < coinArray.Length; i++)
            {
                if (currentSum == desiredSum)
                {
                    break;
                }

                int currentCoin = coinArray[i]; //50
                int numberOfCoins = 0;

                if (currentCoin > desiredSum - currentSum)
                {
                    continue;
                }

                numberOfCoins = (desiredSum - currentSum) / currentCoin;
                currentSum += numberOfCoins * currentCoin;

                coinDictionary.Add(currentCoin, numberOfCoins);
            }

            if (currentSum != desiredSum)
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine($"Number of coins to take: {coinDictionary.Values.Sum()}");

            foreach (var coin in coinDictionary)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
    }
}
