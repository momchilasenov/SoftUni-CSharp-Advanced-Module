using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people;

        public Family()
        {
            this.people = new List<Person>(); //със създаването на ново семейство създаваш и нов лист
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestPerson;
        }
    }
}
