using System;
using System.Linq;

namespace P08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = string.Join(" ", firstInput.Skip(3));
            var personInfo = new MyThreeuple<string, string, string>(fullName, address, town);

            string[] secondInput = Console.ReadLine().Split();
            string name = secondInput[0];
            int beer = int.Parse(secondInput[1]);
            string drunkLevel = secondInput[2];
            string drunkOrNot = drunkLevel == "drunk" ? "True" : "False";
            var personBeer = new MyThreeuple<string, int, string>(name, beer, drunkOrNot);

            string[] thirdInput = Console.ReadLine().Split();
            string newName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bank = thirdInput[2];
            var numbers = new MyThreeuple<string, double, string>(newName, accountBalance, bank);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbers);
        }
    }
}
