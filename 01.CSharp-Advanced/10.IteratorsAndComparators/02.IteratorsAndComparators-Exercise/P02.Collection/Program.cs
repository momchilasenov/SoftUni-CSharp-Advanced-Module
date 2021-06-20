using System;
using System.Linq;
using System.Collections.Generic;


namespace P02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = Console.ReadLine();

            List<string> elements = token
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    bool result = listyIterator.HasNext();
                    Console.WriteLine(result);
                }
                else if (command == "Move")
                {
                    bool result = listyIterator.Move();
                    Console.WriteLine(result);
                }
                else if (command == "PrintAll")
                {
                    foreach(var element in elements)
                    {
                        Console.Write(element + " ");
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
