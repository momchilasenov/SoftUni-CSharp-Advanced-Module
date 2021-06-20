using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            int[] plateData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> plates = new Queue<int>(plateData);
            Stack<int> orcs = new Stack<int>();

            List<int> platesList = new List<int>(plateData);

            for (int i = 1; i <= waves; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                orcs = new Stack<int>(orcData); int[] orcData = Console.ReadLine()
               

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                    platestList.Add(newPlate);
                }

                int currentPlate = plates.Peek();

                while (currentPlate > 0 && orcs.Count > 0 && plates.Count>0)
                {
                    int currentOrc = orcs.Peek();

                    if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;
                        platesList[0] = currentPlate;
                        orcs.Pop();
                    }
                    else if (currentOrc > currentPlate)
                    {
                        while (currentOrc >= 0 && plates.Count>0)
                        {
                            currentOrc -= currentPlate;

                            if (plates.Count == 0)
                            {
                                break;
                            }

                            plates.Dequeue();
                            platesList.RemoveAt(0);

                            if (plates.Count > 0)
                            {
                                currentPlate = plates.Peek();
                            }
                            
                        }
                        if (orcs.Count > 0)
                        {
                            orcs.Pop();
                            orcs.Push(currentOrc);
                        }
                    }
                    else if (currentPlate == currentOrc)
                    {
                        platesList.RemoveAt(0);
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesList)}");
            }
        }
    }
}
