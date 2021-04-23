using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.PredicateParty2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFunc = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFunc = (name, param) => name.EndsWith(param);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                string[] commands = input.Split();
                string action = commands[0];
                string condition = commands[1];
                string param = commands[2];

                if (action == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);

                        List<string> tempNames = names.Where(name => lengthFunc(name, length)).ToList();

                        names = SetTempNames(names, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        List<string> tempNames = names.Where(name => startsWithFunc(name, param)).ToList();

                        names = SetTempNames(names, tempNames);
                    }
                    else if (condition == "EndsWith")
                    {
                        List<string> tempNames = names.Where(name => endsWithFunc(name, param)).ToList();

                        names = SetTempNames(names, tempNames);
                    }
                }
                else if (action == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);

                        names = names.Where(name => !lengthFunc(name, length)).ToList();
                    }
                    else if (condition == "StartsWith")
                    {
                        names = names.Where(name => !startsWithFunc(name, param)).ToList();

                    }
                    else if (condition == "EndsWith")
                    {
                        names = names.Where(name => !endsWithFunc(name, param)).ToList();
                    }
                }
            }

            if (names.Count <= 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }

        }

        static List<string> SetTempNames(List<string> names, List<string> tempNames)
        {
            foreach (string currentName in tempNames)
            {
                int index = names.IndexOf(currentName);
                names.Insert(index, currentName);

            }
            return names;
        }
    }
}
