using System;

namespace P05.GenericCountMethodString
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

            string compareValue = Console.ReadLine();

            Console.WriteLine(box.CompareElements(compareValue));
        }
    }
}
