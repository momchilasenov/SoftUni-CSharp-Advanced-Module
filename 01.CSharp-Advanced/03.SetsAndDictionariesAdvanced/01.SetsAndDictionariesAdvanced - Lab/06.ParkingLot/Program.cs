using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");
                string command = input[0];

                if (command == "END")
                {
                    break;
                }

                string carNumber = input[1];

                if (command == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
