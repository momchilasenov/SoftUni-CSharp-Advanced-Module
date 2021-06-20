using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(4, 5);
            Console.WriteLine(scale.AreEqual());

            EqualityScale<string> scale2 = new EqualityScale<string>("Momchil", "Hristo");
            Console.WriteLine(scale2.AreEqual());

            EqualityScale<bool> scale3 = new EqualityScale<bool>(2 == 2, 3 == 3);
            Console.WriteLine(scale3.AreEqual());

        }
    }
}
