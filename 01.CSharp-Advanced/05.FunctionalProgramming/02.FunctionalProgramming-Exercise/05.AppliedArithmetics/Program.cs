using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;
            Action<int[]> print = numbers => Console.WriteLine(string.Join(' ', numbers));

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                for (int i = 0; i < numbers.Length; i++)
                { //or use Select() to apply function to all numbers automatically (select() returns new array)
                    switch (input)
                    {
                        case "add":
                            numbers[i] = add(numbers[i]);
                            break;
                        case "multiply":
                            numbers[i] = multiply(numbers[i]);
                            break;
                        case "subtract":
                            numbers[i] = subtract(numbers[i]);
                            break;
                        case "print":
                            print(numbers);
                            break;
                    }

                    if (input == "print")
                    {
                        break;
                    }
                }
            }
        }
    }
}
