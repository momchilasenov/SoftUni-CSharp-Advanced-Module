using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConstraints
{
    public class Student<T>
        where T : new()
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Student()
        {

        }

        public void AddEmpty<TM>(TM value)
            where TM : T
        {
            
        }


        public string Name { get; set; }

        public int Age { get; set; }
    }
}
