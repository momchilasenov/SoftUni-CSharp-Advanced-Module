using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person pesho = new Person();
            Console.WriteLine(pesho.Name);
            Console.WriteLine(pesho.Age);

            Person misho = new Person(26);
            Console.WriteLine(misho.Name);
            Console.WriteLine(misho.Age);

            Person tosho = new Person("Tosho", 25);
            Console.WriteLine(tosho.Name);
            Console.WriteLine(tosho.Age);
        }
    }
}
