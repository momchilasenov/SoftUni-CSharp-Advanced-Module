using System;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                people[i] = new Person() { Name = input[0], Age = int.Parse(input[1]) };
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            
            Func<Person, bool> predicate = person => true; 

            if (filter == "older")
            {
                predicate = person => person.Age >= filterAge;
            }
            else if (filter == "younger")
            {
                predicate = person => person.Age < filterAge;
            }

            Person[] filteredPeople = people.Where(predicate).ToArray();

            string format = Console.ReadLine();

            Action<Person> printPredicate = null;

            if (format == "name")
            {
                printPredicate = person => Console.WriteLine(person.Name);
            }
            else if (format == "age")
            {
                printPredicate = person => Console.WriteLine(person.Age);
            }
            else if (format == "name age")
            {
                printPredicate = person => Console.WriteLine($"{person.Name} - {person.Age}");
            }

            foreach (var person in filteredPeople)
            {
                printPredicate(person);
            }
        }
    }
}
