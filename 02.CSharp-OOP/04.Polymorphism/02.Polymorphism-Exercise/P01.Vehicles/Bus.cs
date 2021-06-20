using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditioner = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double capacity)
            :base(fuelQuantity, fuelConsumption, BusAirConditioner, capacity)
        {
            
        }

        public void DriveEmpty(double distance)
        {
            double requiredFuel = this.FuelConsumption * distance;

            if (requiredFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            this.FuelQuantity -= requiredFuel;
        }

    }
}
