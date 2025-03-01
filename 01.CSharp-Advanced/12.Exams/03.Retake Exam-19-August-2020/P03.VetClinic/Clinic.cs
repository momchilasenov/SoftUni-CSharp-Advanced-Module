﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.pets.Count; }
        }

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            foreach (Pet pet in pets)
            {
                if (pet.Name == name)
                {
                    pets.Remove(pet);
                    return true;
                }
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet returnPet = pets.Any(p => (p.Name == name) && (p.Owner == owner))
                ? returnPet = pets.FirstOrDefault(p => (p.Name == name) && (p.Owner == owner))
                : returnPet = null;

            return returnPet;
        }

        public Pet GetOldestPet()
        {
            return pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
