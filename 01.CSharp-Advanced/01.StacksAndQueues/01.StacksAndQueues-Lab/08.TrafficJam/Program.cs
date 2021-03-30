using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsCanPass = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int counter = 0;

            Queue<string> carsQueue = new Queue<string>();

            while (input != "end")
            {
                if (input != "green")
                {
                    carsQueue.Enqueue(input);
                }
                else
                {
                    if (carsCanPass <= carsQueue.Count)
                    {
                        for (int i = 0; i < carsCanPass; i++)
                        {
                            string currentCar = carsQueue.Dequeue();
                            Console.WriteLine($"{currentCar} passed!");
                            counter++;
                        }
                    }
                    else
                    {
                        while (carsQueue.Count > 0)
                        {
                            string currentCar = carsQueue.Dequeue();
                            Console.WriteLine($"{currentCar} passed!");
                            counter++;
                        }
                    }
                    
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
