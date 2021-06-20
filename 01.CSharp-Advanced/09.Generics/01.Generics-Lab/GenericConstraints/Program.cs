using System;

namespace GenericConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            Student<int> gosho = new Student<int>("Gosho", 24);
            Console.WriteLine(gosho.Name);
            Console.WriteLine(gosho.Age);

            
        }
    }
}
