using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private HashSet<Racer> racers;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new HashSet<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.racers.Count();

        public void Add(Racer racer)
        {
            if (racers.Count < this.Capacity)
            {
                racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            foreach(Racer racer in racers)
            {
                if (racer.Name == name)
                {
                    racers.Remove(racer);
                    return true;
                }
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return racers.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            foreach(Racer racer in racers)
            {
                if (racer.Name == name)
                {
                    return racer;
                }
            }
            return null;
        }

        public Racer GetFastestRacer()
        {
            return racers.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach(var racer in racers)
            {
                sb.AppendLine($"{racer}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
