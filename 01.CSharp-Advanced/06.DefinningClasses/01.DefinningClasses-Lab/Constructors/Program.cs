using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Student pesho = new Student("Pesho");
            Console.WriteLine(pesho.Name); //pesho.Name is already set to "Pesho"

            Student momchil = new Student("Momchil", 24);

        }
    }
}
