using System;

namespace P04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                box.Values.Add(value);
            }

            string[] input = Console.ReadLine().Split();
            int first = int.Parse(input[0]);
            int second = int.Parse(input[1]);

            box.SwapElements(first, second);

            Console.WriteLine(box);
        }
    }
}
