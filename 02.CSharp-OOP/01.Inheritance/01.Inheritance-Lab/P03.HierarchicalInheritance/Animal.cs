using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{ 
    public class Animal
    {
        public Animal(string name)
        {
            Console.WriteLine($"{name} constructor");
        }

        public void Eat()
        {
            Console.WriteLine("eating...");
        }

    }
}
