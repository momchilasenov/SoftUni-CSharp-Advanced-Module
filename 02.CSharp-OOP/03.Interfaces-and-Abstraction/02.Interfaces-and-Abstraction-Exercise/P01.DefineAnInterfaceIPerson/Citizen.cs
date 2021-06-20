using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
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

        public string Birthdate { get; private set; }

        public string Id { get; private set; }
    }
}
