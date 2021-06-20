using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name) != 0)
            {
                return this.name.CompareTo(other.name);
            }

            return this.age.CompareTo(other.age);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode()+this.age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;

            if (person.name == this.name && person.age == this.age)
            {
                return true;
            }
            return false;
        }
    }
}
