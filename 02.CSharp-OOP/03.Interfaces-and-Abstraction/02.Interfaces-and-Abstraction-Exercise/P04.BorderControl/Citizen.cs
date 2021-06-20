using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }
        public int Age
        {
            get => this.age;
            private set => this.age = value;
        }     

        public string Id { get; private set; }
    }
}
