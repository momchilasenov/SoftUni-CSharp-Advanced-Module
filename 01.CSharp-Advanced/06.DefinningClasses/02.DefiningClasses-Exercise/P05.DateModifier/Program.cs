using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier modifier = new DateModifier();

            double result = modifier.CalculateDays(firstDate, secondDate);

            Console.WriteLine(Math.Abs(result));
        }
    }
}
