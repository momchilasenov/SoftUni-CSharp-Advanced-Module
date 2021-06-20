using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private HashSet<Car> cars;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new HashSet<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.cars.Count; }
        }

        public void Add(Car car)
        {
            if (cars.Count < this.Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = cars
                .Where(car => (car.Manufacturer == manufacturer) && (car.Model == model))
                .FirstOrDefault();

            if (car != null)
            {
                cars.Remove(car);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (cars.Count == 0)
            {
                return null;
            }

            return cars.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            foreach(Car car in cars)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in cars)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
