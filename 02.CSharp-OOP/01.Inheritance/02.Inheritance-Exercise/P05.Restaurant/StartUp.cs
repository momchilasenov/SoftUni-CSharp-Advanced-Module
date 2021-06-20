using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var coffee = new Coffee("Chibo", 30);

            Console.WriteLine(coffee.Price);
        }
    }
}
