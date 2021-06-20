using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClasses
{
    public abstract class Dog
    {
        public abstract void WalkDog();

        public virtual void CuddleWithDog()
        {
            Console.WriteLine("Dog cuddle method");
        }
    }
}
