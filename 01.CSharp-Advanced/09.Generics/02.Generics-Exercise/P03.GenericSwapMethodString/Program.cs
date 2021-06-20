using System;

namespace P03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
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
