using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] casingsArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bombCasings = new Stack<int>(casingsArray);
            Queue<int> bombEffects = new Queue<int>(effectsArray);

            int datura = 0;
            int cherry = 0;
            int smoke = 0;

            while (bombEffects.Count != 0 && bombCasings.Count != 0)
            {
                int currentCasing = bombCasings.Peek();
                int currentEffect = bombEffects.Peek();

                while (true)
                {
                    int sum = currentCasing + currentEffect;

                    if (sum == 40)
                    {
                        datura++;
                        bombCasings.Pop();
                        bombEffects.Dequeue();
                        break;
                    }
                    else if (sum == 60)
                    {
                        cherry++;
                        bombCasings.Pop();
                        bombEffects.Dequeue();
                        break;
                    }
                    else if (sum == 120)
                    {
                        smoke++;
                        bombCasings.Pop();
                        bombEffects.Dequeue();
                        break;
                    }
                    else
                    {
                        currentCasing -= 5;
                        bombCasings.Pop();
                        bombCasings.Push(currentCasing);
                    }
                }

                if (datura >= 3 && smoke >= 3 && cherry >= 3)
                {
                    break;
                }
            }

            string pouchIsFull = datura >= 3 && smoke >= 3 && cherry >= 3
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.";
            Console.WriteLine(pouchIsFull);

            string bombEffectsString = bombEffects.Count == 0 
                ? $"Bomb Effects: empty" 
                : $"Bomb Effects: {string.Join(", ", bombEffects)}";
            Console.WriteLine(bombEffectsString);

            string bombCasingsString = bombCasings.Count == 0
                ? $"Bomb Casings: empty"
                : $"Bomb Casings: {string.Join(", ", bombCasings)}";
            Console.WriteLine(bombCasingsString);

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");


        }
    }
}
