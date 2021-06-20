using System;
using System.Collections.Generic;

namespace P05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdateList = new List<IBirthable>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] data = line.Split();

                if (data[0] == "Citizen")
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthdate = data[4];

                    Citizen citizen = new Citizen(name, age, birthdate, id);
                    birthdateList.Add(citizen);
                }
                else if (data[0] == "Pet")
                {
                    string name = data[1];
                    string birthdate = data[2];
                    Pet pet = new Pet(name, birthdate);
                    birthdateList.Add(pet);
                }

            }

            string year = Console.ReadLine();

            foreach (var birthdate in birthdateList)
            {
                if (birthdate.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthdate.Birthdate);
                }
            }

        }
    }
}
