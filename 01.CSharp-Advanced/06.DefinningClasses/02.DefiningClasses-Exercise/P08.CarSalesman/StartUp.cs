using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            //Engine
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //"{model} {power} {displacement:optional} {efficiency:optional}"
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] engineData = new string[4];

                for (int j = 0; j < input.Length; j++)
                {
                    engineData[j] = input[j];
                }

                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                string displacement = null;
                string efficiency = null;

                if (engineData[2] != null)
                {
                    if (char.IsDigit(engineData[2][0]))
                    {
                        displacement = engineData[2];
                    }
                    else
                    {
                        efficiency = engineData[2];
                    }
                }
                if (engineData[3] != null)
                {
                    if (char.IsDigit(engineData[3][0]))
                    {
                        displacement = engineData[3];
                    }
                    else
                    {
                        efficiency = engineData[3];
                    }
                }

                Engine currentEngine = new Engine()
                {
                    Model = model,
                    Power = power,
                    Displacement = displacement,
                    Efficiency = efficiency
                };

                engines.Add(currentEngine);
            }

            //Car
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                //"{model} {engine} {weight:optional} {color:optional}" 
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] carData = new string[4];

                Car currentCar = new Car();

                for (int j = 0; j < input.Length; j++)
                {
                    carData[j] = input[j];
                }

                string model = carData[0];
                
                foreach (Engine engine in engines)
                {
                    if (engine.Model == carData[1])
                    {
                        currentCar.Engine = engine;
                        break;
                    }
                }

                string weight = null;
                string color = null;

                if (carData[2] != null)
                {
                    if (char.IsDigit(carData[2][0]))
                    {
                        weight = carData[2];
                    }
                    else
                    {
                        color = carData[2];
                    }
                }
                if (carData[3] != null)
                {
                    if (char.IsDigit(carData[3][0]))
                    {
                        weight = carData[3];
                    }
                    else
                    {
                        color = carData[3];
                    }
                }

                currentCar.Model = model;
                currentCar.Color = color;
                currentCar.Weight = weight;

                cars.Add(currentCar);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
