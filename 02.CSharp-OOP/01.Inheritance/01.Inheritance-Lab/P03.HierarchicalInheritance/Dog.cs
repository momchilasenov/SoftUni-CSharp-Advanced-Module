using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Dog : Animal
    {
        public Dog() : base("Misha")
        {
            Console.WriteLine("Dog constructor");
        }

        public void Bark()
        {
            Console.WriteLine("barking...");
        }
    }
}
