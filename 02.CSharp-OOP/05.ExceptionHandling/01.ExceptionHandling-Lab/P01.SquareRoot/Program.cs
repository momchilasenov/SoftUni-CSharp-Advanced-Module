using System;

namespace P01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                Sqrt(number);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static double Sqrt(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Invalid number");
            }

            return Math.Sqrt(number);
        }
    }
}
