using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.TheFightForGondor_AfterExam
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //1.Read waves of orcs
            int numberOfWaves = int.Parse(Console.ReadLine());

            //2.Read plates
            int[] plateData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> plates = new List<int>(plateData);
            Stack<int> orcWave = new Stack<int>();

            // 3.For loop for all the waves of orcs - store the currentWave in a Stack
            //3.1. check if current wave is % 3 == 0 -> if so, read new plate

            for (int i = 1; i <= numberOfWaves; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                int[] waveData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                orcWave = new Stack<int>(waveData);

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                //read plate outside while loop
                int currentPlate = plates[0]; 

                //4.1.Until there are no more plates or orcs, 
                //the last orc warrior attacks the first plate:
                while (plates.Count > 0 && orcWave.Count > 0)
                {
                    int currentOrc = orcWave.Peek();

                    if (currentOrc > currentPlate)
                    {
                        //If the warrior's value is greater, he destroys the plate and lowers his value by the plate's value, then attacks the next plate, until his value reaches 0.

                        currentOrc -= currentPlate;
                        plates.RemoveAt(0);
                        //update the orc value in the wave
                        orcWave.Pop();
                        orcWave.Push(currentOrc);

                        //if there is more than 1 plate, return it's value
                        if (plates.Count > 0)
                        {
                            currentPlate = plates[0];
                        }

                        continue;
                    }
                    else if (currentPlate > currentOrc)
                    {
                        //If the plate's value is greater, the warrior dies and the plate decreases its value by the warrior's value.
                        currentPlate -= currentOrc;
                        plates[0] = currentPlate; //update the plate value in the List
                        orcWave.Pop();
                    }
                    else if (currentPlate == currentOrc)
                    {
                        //If their values are equal, the warrior dies and the plate is destroyed.
                        plates.RemoveAt(0);
                        orcWave.Pop();
                    }
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcWave)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

        }
    }
}
