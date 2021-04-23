using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = null;

                string model = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                if (engineArgs.Length == 4)
                {
                    int displacement = int.Parse(engineArgs[2]);
                    string efficiency = engineArgs[3];

                    engine = new Engine(model, power, efficiency);
                }
                else if (engineArgs.Length == 3)
                {
                    int displacement; //assume the arg is displacement

                    bool isDisplacement = int.TryParse(engineArgs[2], out displacement);
                    //try to parse the second argument and if you succeed return displacement

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArgs[2]);
                    }
                }
                else if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }

            }

            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                //"{model} {engine} {weight:optional} {color:optional}" 
                string[] carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                Engine engine = engines.First(e => e.Model == carArgs[1]);
                //return the first engine where engine.Model matches the given engine

                Car car = null;

                if (carArgs.Length == 4)
                {
                    int weight = int.Parse(carArgs[2]);
                    string color = carArgs[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (carArgs.Length == 3)
                {
                    int weight;

                    bool isWeight = int.TryParse(carArgs[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carArgs[2]);
                    }
                }
                else if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            foreach(var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
