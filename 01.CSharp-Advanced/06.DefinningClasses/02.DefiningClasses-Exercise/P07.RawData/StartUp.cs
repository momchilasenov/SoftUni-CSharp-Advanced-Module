using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Age, tire1Pressure, tire2Age, tire2Pressure, tire3Age, tire3Pressure, tire4Age, tire4Pressure);

                cars.Add(car);
            }

            string input = Console.ReadLine();

            if (input == "fragile")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.CargoType == "fragile" && car.Tires.Any(t => t.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (input == "flamable")
            {
                foreach(Car car in cars)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }

            }
        }
    }
}
