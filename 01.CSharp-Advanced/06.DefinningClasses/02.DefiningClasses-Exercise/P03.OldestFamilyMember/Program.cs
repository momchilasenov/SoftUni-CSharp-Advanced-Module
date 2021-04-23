using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            //family.people = new List<Person>(); //in the ctor you have created a new list

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person currentPerson = new Person(name, age);

                family.AddMember(currentPerson);
            }

            Person maxPerson = family.GetOldestMember(family.people);

            Console.WriteLine($"{maxPerson.Name} {maxPerson.Age}");


        }
    }
}
