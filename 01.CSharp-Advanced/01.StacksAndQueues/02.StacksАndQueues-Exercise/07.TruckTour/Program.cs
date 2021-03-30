using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            //int petrolPumps = int.Parse(Console.ReadLine());

            //Queue<int> indexQueue = new Queue<int>();
            //Queue<int> petrolQueue = new Queue<int>();
            //Queue<int> distanceQueue = new Queue<int>();

            //for (int i = 0; i < petrolPumps; i++)
            //{
            //    int[] data = Console.ReadLine()
            //        .Split()
            //        .Select(int.Parse)
            //        .ToArray();

            //    int petrol = data[0];
            //    int distance = data[1];

            //    indexQueue.Enqueue(i);
            //    petrolQueue.Enqueue(petrol);
            //    distanceQueue.Enqueue(distance);

            //}

            //int totalDistance = distanceQueue.Sum();
            //int totalPetrol = 0;
            //bool isOptimal = false;

            //while (isOptimal == false)
            //{
            //    for (int i = 0; i < petrolPumps; i++)
            //    {
            //        int currentIndex = indexQueue.Dequeue();
            //        indexQueue.Enqueue(currentIndex);

            //        int currentPetrol = petrolQueue.Dequeue();
            //        petrolQueue.Enqueue(currentPetrol);

            //        int currentDistance = distanceQueue.Dequeue();
            //        distanceQueue.Enqueue(currentDistance);

            //        totalPetrol += currentPetrol;

            //        if (totalPetrol >= currentDistance)
            //        {
            //            totalPetrol -= currentDistance;
            //            isOptimal = true;
            //        }
            //        else
            //        {
            //            isOptimal = false;
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine(indexQueue.Dequeue());


            //Alternative Solution
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}"; //adds the index of the pump to the fuel and distance data
                circle.Enqueue(input);
            }

            int totalFuel = 0;

            for (int i = 0; i < numberOfPumps; i++)
            {
                string currentInfo = circle.Dequeue();
                int[] info = currentInfo.Split().Select(int.Parse).ToArray();

                int fuel = info[0];
                int distance = info[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1; //goes back one step to run the cycle from the start
                }
                circle.Enqueue(currentInfo);
            }

            string[] firstElement = circle.Dequeue().Split().ToArray();
            Console.WriteLine(firstElement[2]);

        }
    }
}
