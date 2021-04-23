using System;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person currentPerson = new Person(name, age);

                family.AddMember(currentPerson);
            }

            Console.WriteLine(family.GetOldestMember()); //the oldest person is taken from the method and ToString() is overriden 
            
        }
    }
}
