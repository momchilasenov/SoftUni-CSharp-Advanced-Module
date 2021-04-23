using System;
using System.Collections.Generic;
using System.Text;

namespace Constructors
{
    class Student
    {
        public Student()
        {
            //this is how a default constructor looks like (it has no parameters)
            averageGrade = 2;
        }

        private int averageGrade;
        public Student(string name) 
            :this() //reuses the code written in the default constructor
        {
            this.Name = name; //set-ваш името да е това, което е подадено в конструктора
        }

        public Student(string name, int age)
            : this(name) //reuses the code written in the 1 param constructor
        {
            //this.Name = name; ->no point to set it since we're calling the other constructor
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        
    }
}
