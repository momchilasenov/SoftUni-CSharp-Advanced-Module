using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClasses
{
    public class Retriever : Dog
    {
        public override void WalkDog()
        {
            Console.WriteLine("Walking dog");
        }

        public override void CuddleWithDog()
        {
            Console.WriteLine("Retriever cuddle method");
        }
    }
}
