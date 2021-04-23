using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<int, Tire[]> tires = new Dictionary<int, Tire[]>();
            int counter = 0;

            while (input != "No more tires")
            {
                double[] tireData = input.Split().Select(double.Parse).ToArray();
                Tire[] tireArray = new Tire[4];

                for (int i = 0; i < tireData.Length / 2.0; i++)
                {
                    tireArray[i] = new Tire((int)tireData[i], tireData[i + 1]);
                }

                tires.Add(counter, tireArray);

                counter++;

                input = Console.ReadLine();
            }

            string token = Console.ReadLine();
            Dictionary<int, Engine> engines = new Dictionary<int, Engine>();
            int engineCounter = 0;

            while (token != "Engines done")
            {
                double[] engineData = token.Split().Select(double.Parse).ToArray();
                int horsePower = (int)engineData[0];
                double cubicCapacity = engineData[1];

                engines.Add(engineCounter, new Engine(horsePower, cubicCapacity));

                engineCounter++;

                token = Console.ReadLine();
            }

            string carInput = Console.ReadLine();
            Dictionary<int, Car> cars = new Dictionary<int, Car>();
            int carCounter = 0;

            while (carInput != "Show special")
            {
                string[] carData = carInput.Split();

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                if (engineIndex >= 0 && engineIndex<engines.Count && tiresIndex >= 0 && tiresIndex < tires.Count)
                {
                    Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                    cars.Add(carCounter, car);
                }

                carCounter++;

                carInput = Console.ReadLine();
            }

            cars = cars
                .Where(car => car.Value.Year >= 2017
                && car.Value.Engine.HorsePower >= 330
                && car.Value.Tires.Sum(y => y.Pressure) >= 9
                && car.Value.Tires.Sum(y => y.Pressure) <= 10)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var car in cars)
            {
                car.Value.Drive(20);

                Console.WriteLine(car.Value.WhoAmI());
            }

        }
    }
}
