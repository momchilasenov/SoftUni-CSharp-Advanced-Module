using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people;

        public Family() //имаш ли колекция от обекти, създаваш нов обект в конструктора
        {
            this.people = new List<Person>(); //инициализация на листа в конструктора
        }

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

            //Алтернативен метод
            //Person oldestPerson = this.people
            //    .OrderByDescending(p => p.Age)
            //    .FirstOrDefault();

            //return oldestPerson;

        }
    }
}
