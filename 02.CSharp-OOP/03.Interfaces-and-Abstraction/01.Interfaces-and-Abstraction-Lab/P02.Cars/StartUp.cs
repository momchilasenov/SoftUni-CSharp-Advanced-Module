using System;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Ibiza", "Black");
            ICar tesla = new Tesla("Fury", "White", 4);

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
        }
    }
}
