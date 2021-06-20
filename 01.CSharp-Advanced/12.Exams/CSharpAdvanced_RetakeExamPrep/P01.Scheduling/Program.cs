using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(taskArray);
            Queue<int> threads = new Queue<int>(threadArray);

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine
                        ($"Thread with value {currentThread} killed task {currentTask}");
                    break;
                }

                if (currentThread >= currentTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }

            }

            Console.WriteLine(string.Join(" ", threads));

        }
    }
}
