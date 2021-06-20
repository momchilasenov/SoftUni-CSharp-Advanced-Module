using System;

namespace P06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());
                box.Values.Add(value);
            }

            double compareValue = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CompareElements(compareValue));
        }
    }
}
