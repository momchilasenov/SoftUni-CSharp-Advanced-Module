using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>(this.Capacity = capacity);
        }

        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }
            else if (cars.Count >= cars.Capacity)
            {
                return "Parking is full!";

            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars = cars.Where(c => c.RegistrationNumber != registrationNumber).ToList();
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber) //note have to check if car exists?
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach(string regNumber in registrationNumbers)
            {
                cars = cars.Where(c => c.RegistrationNumber != regNumber).ToList();
            }
        }
    }
}
