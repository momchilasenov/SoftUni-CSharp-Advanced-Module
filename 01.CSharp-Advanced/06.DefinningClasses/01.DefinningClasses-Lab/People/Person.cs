using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    class Person
    {
        private string name;
        private string lastName = "Peshov"; //we set all last names to Peshov
        private int age;

        public string FullName
        {
            get { return $"{name} {lastName}"; } //the getter will return whatever is in the method
        }

        public string Name //actually a placeholder for private string name;
        {
            get { return name; } //what a standard get method looks like

            set 
            {  
                if (value.Length < 3 || value.Length > 50) //validated the data before setting the name
                {   //value е текущата стойност, която се задава (set-ва)
                    Console.WriteLine("Invalid name");
                }
                else
                {
                    name = value; //what a set method looks like
                }
            } 
        }
    }
}
