using System;
using System.Collections.Generic;

namespace P01.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Divide and conquer
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int carsPassed = 0;

            Queue<string> carQueue = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command != "green")
                {
                    carQueue.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }

                int greenLight = greenLightDuration;
                int freeWindow = freeWindowDuration;

                while (greenLight > 0 && carQueue.Count > 0)
                {
                    string currentCar = carQueue.Peek();
                    string car = currentCar;
                    int carLength = currentCar.Length;

                    if (carLength <= greenLight)
                    {
                        carQueue.Dequeue();
                        greenLight -= currentCar.Length;
                        carsPassed++;
                    }
                    else if (carLength > greenLight) // 10 8
                    {
                        carLength -= greenLight;
                        currentCar = currentCar.Remove(0, greenLight);

                        if (carLength <= freeWindow)
                        {
                            carQueue.Dequeue();
                            greenLight -= carLength;
                            carsPassed++;
                            break;
                        }
                        else if (carLength > freeWindow) //5 3
                        {
                            currentCar = currentCar.Remove(0, freeWindow);
                            string charHit = currentCar[0].ToString();
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {charHit}.");
                            Environment.Exit(0);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

        }
    }
}
