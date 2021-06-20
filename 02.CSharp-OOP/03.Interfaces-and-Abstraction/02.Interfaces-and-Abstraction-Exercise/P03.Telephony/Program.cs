using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split(' ');

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationary = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        smartphone.Calling(number);
                    }
                    else if (number.Length == 7)
                    {
                        stationary.Calling(number);
                    }
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            foreach (var url in urls)
            {
                try
                {
                    smartphone.Browse(url);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
