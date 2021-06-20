using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> tasks = new Stack<int>(tasksData);

            int[] queueData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> threads = new Queue<int>(queueData);

            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Peek() != taskToKill)
            {
                int thread = threads.Peek();
                int task = tasks.Peek();

                if (thread >= task)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            int killerThread = threads.Peek();
            Console.WriteLine($"Thread with value {killerThread} killed task {taskToKill}");
            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
