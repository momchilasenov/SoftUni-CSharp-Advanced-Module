using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                string[] commands = input.Split();

                foreach (var person in people)
                {
                    Func<string, bool> criteria = GetCriteria(commands, person);

                    if (criteria(person))
                    {
                        ListModifier(commands, people, person);
                    }
                }
            }
        }

        static Func<string, bool> GetCriteria(string[] commands, string person)
        {
            string command = commands[0];
            string condition = commands[1];
            string conditionSpecific = commands[2];

            if (condition == "StartsWith")
            {
                return person => person.StartsWith(conditionSpecific);
            }
            else if (condition == "EndsWith")
            {
                return person => person.EndsWith(conditionSpecific);
            }
            else if (condition == "Length")
            {
                int conditionNumber = int.Parse(commands[2]);
                return person => person.Length == conditionNumber;
            }

            return null;
        }

        static List<string> ListModifier(string[] commands, List<string> people, string person)
        {
            string command = commands[0];
            int counter = 0;
            int resultGuests = 0;


            if (command == "Double")
            {
                foreach (var guest in people)
                {
                    if (guest == person)
                    {
                        counter++;
                    }
                }

                resultGuests = counter * 2;
                for (int i = 0; i < resultGuests; i++)
                {
                    people.Add(person);
                }

                return people;
            }
            else if (command == "Remove")
            {
                people.RemoveAll(guest => guest == person);
                return people;
            }

            return null;
        }
    }
}
