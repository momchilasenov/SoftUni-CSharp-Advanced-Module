
namespace P07.Tuple
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            MyTuple<string, string> personInfo = new MyTuple<string, string>(fullName, address);

            string[] secondInput = Console.ReadLine().Split();
            string name = secondInput[0];
            int beer = int.Parse(secondInput[1]);
            MyTuple<string, int> personBeer = new MyTuple<string, int>(name, beer);

            string[] thirdInput = Console.ReadLine().Split();
            int number = int.Parse(thirdInput[0]);
            double doubleNumber = double.Parse(thirdInput[1]);
            MyTuple<int, double> numbers = new MyTuple<int, double>(number, doubleNumber);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbers);

        }
    }
}
