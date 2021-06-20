using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] personData = input.Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int number = int.Parse(Console.ReadLine());

            Person personToCompare = people[number - 1];

            int matches = 1;

            foreach (var person in people)
            {

                if (person.CompareTo(personToCompare) == 0 && !person.Equals(personToCompare))
                {
                    matches++;
                }

            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}
