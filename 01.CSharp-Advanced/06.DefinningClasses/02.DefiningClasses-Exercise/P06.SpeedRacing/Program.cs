using System;
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
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(currentCar);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputData = input.Split();
                string carModel = inputData[1].Trim();
                double amountOfKm = double.Parse(inputData[2]);
                
                foreach(Car car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.DriveCar(amountOfKm);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                car.PrintCar();
            }

        }
    }
}
