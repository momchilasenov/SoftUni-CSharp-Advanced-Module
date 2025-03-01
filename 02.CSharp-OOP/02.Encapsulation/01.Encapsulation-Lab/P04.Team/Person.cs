﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private decimal DefaultMinimalWage = 460;
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value < DefaultMinimalWage)
                {
                    throw new ArgumentException($"Salary cannot be less than {DefaultMinimalWage} leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.age < 30)
            {
                this.salary += this.salary * (percentage / 100) / 2;
            }
            else
            {
                this.salary += this.salary * (percentage / 100);
            }

            //alternative
            //if (this.Age < 30) { percentage /= 2;}
            //this.Salary *= 1 + (percentage / 100);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
