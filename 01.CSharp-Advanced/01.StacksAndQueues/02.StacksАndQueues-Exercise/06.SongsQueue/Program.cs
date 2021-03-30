using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Queue<string> songsQueue = new Queue<string>(songs);

            while (true)
            {
                string commands = Console.ReadLine();

                if (songsQueue.Count > 0)
                {
                    if (commands == "Play")
                    {
                        songsQueue.Dequeue();
                    }
                    else if (commands.Contains("Add"))
                    {
                        string songToAdd = commands.Substring(4);
                        if (songsQueue.Contains(songToAdd))
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }
                        else
                        {
                            songsQueue.Enqueue(songToAdd);
                        }
                    }
                    else if (commands == "Show")
                    {
                        Console.WriteLine(string.Join(", ", songsQueue));
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
