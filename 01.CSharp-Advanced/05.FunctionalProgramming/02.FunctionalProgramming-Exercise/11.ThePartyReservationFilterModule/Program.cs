using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();

            Func<string, string, bool> startsWithFunc = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFunc = (name, param) => name.EndsWith(param);
            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
            Func<string, string, bool> containsFunc = (name, param) => name.Contains(param);

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] commands = input.Split(';');
                string command = commands[0];
                string condition = commands[1];
                string param = commands[2];

                if (command == "Add filter")
                {
                    filters.Add($"{condition} {param}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{condition} {param}");
                }

                input = Console.ReadLine();
            }

            foreach (string filter in filters)
            {
                string[] commands = filter.Split();
                string condition = commands[0];

                if (condition == "Starts")
                {
                    names = names.Where(name => startsWithFunc(name, commands[2]) == false).ToList();
                }
                else if (condition == "Ends")
                {
                    names = names.Where(name => endsWithFunc(name, commands[2]) == false).ToList();
                }
                else if (condition == "Length")
                {
                    int length = int.Parse(commands[1]);
                    names = names.Where(name => lengthFunc(name, length) == false).ToList();
                }
                else if (condition == "Contains")
                {
                    names = names.Where(name => containsFunc(name, commands[1]) == false).ToList();
                }
            }

            Console.WriteLine(string.Join(' ', names));

        }
    }
}
