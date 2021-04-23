using System;

namespace Practice
{
    class Program
    {
        static int number = 5; //global field accessible everywhere in class Program

        static void Main(string[] args)
        {
            Console.WriteLine(number);


            Shirt adidas = new Shirt();
            adidas.Price = 78;
            adidas.Size = "L";


            Shirt nike = new Shirt(){ Price = 10, Quantity = 7, Size = "M" };

            Bear gogi = new Bear() { Name = "Gogi", Age = 28, DaysSinceLastMeal = 5 };
            Bear ivo = new Bear() { Name = "Ivo", Age = 12, DaysSinceLastMeal = 2 };
            Bear misho = new Bear() { Name = "Misho", Age = 29, DaysSinceLastMeal = 4 };

            Bear[] bears = new Bear[] { gogi, ivo, misho };
            
            foreach (var bear in bears)
            {
                if (bear.DaysSinceLastMeal <= 2)
                {
                    bear.Eat();
                }
            }



        }
    }
}
