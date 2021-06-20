using System;
using System.Linq;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            int[] plateData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> plates = new List<int>(plateData);
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                int[] newOrcWave = Console.ReadLine().Split().Select(int.Parse).ToArray();
                orcs = new Stack<int>(newOrcWave);

                while (plates.Count > 0 && orcs.Count > 0)
                {
                    int currentPlate = plates[0];
                    int currentOrc = orcs.Peek();

                    if (i % 3 == 0)
                    {
                        int newPlate = int.Parse(Console.ReadLine());
                        plates.Add(newPlate);
                    }

                    if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;
                        orcs.Pop();
                        plates.RemoveAt(0);
                        plates.Insert(0, currentPlate);
                    }
                    else if (currentPlate < currentOrc)
                    {
                        while (currentPlate < currentOrc)
                        {
                            currentOrc -= currentPlate;
                            plates.RemoveAt(0);
                            orcs.Pop();
                            orcs.Push(currentOrc);
                        }

                    }
                    else if (currentPlate == currentOrc)
                    {
                        plates.RemoveAt(0);
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
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }

    }
}
