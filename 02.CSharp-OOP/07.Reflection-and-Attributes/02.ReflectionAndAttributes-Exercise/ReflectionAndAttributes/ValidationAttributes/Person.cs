using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequired] //the attribute says - this can't be null or empty
        public string Name { get; private set; }

        [MyRange(MinAge,MaxAge)]
        public int Age { get; private set; }
    }
}
