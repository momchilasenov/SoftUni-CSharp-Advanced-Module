using System;

namespace Enumerations
{
    enum Day
    {
        Monay, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shirt shirt = new Shirt();
            shirt.Size = Size.M;

            SellShirt(Size.M);

            Console.WriteLine(Day.Saturday);
        }

        public static void SellShirt(Size size)
        {
            Console.WriteLine($"Sell shirt with size: {size}");
        }
    }
}
