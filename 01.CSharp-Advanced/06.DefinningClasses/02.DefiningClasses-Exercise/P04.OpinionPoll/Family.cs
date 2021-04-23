using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people;

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember(List<Person> people)
        {
            int maxAge = int.MinValue;
            Person maxPerson = new Person();

            foreach (Person person in people)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    maxPerson = person;
                }
            }
            return maxPerson;
        }
    }
}
