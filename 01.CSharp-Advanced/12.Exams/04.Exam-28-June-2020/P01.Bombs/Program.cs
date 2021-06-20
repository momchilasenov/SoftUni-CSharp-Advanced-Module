using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace P01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int daturaBomb = 40;
            const int cherryBomb = 60;
            const int smokeDecoyBomb = 120;

            int[] effectData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> effects = new Queue<int>(effectData);

            int[] casingData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> casings = new Stack<int>(casingData);

            Dictionary<string, int> bombPouch = new Dictionary<string, int>();
            bombPouch.Add("datura", 0);
            bombPouch.Add("cherry", 0);
            bombPouch.Add("smoke", 0);

            bool pouchIsFull;

            while (true)
            {
                pouchIsFull = bombPouch["datura"] >= 3
                && bombPouch["cherry"] >= 3
                && bombPouch["smoke"] >= 3;

                if ((effects.Count == 0) || (casings.Count == 0) || pouchIsFull)
                {
                    break;
                }

                int currentCasing = casings.Peek();
                int currentEffect = effects.Peek();

                if (currentCasing+currentEffect == daturaBomb)
                {
                    casings.Pop();
                    effects.Dequeue();
                    bombPouch["datura"]++;
                }
                else if (currentCasing + currentEffect == cherryBomb)
                {
                    casings.Pop();
                    effects.Dequeue();
                    bombPouch["cherry"]++;
                }
                else if (currentCasing + currentEffect == smokeDecoyBomb)
                {
                    casings.Pop();
                    effects.Dequeue();
                    bombPouch["smoke"]++;
                }
                else
                {
                    currentCasing -= 5;
                    casings.Pop();
                    casings.Push(currentCasing);
                }

            }

            if (pouchIsFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effects)}");
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            StringBuilder bombBuilder = new StringBuilder();
            bombBuilder.AppendLine($"Cherry Bombs: {bombPouch["cherry"]}");
            bombBuilder.AppendLine($"Datura Bombs: {bombPouch["datura"]}");
            bombBuilder.AppendLine($"Smoke Decoy Bombs: {bombPouch["smoke"]}");

            Console.WriteLine(bombBuilder.ToString().TrimEnd());
        }
    }
}
