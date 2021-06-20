using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditioner = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double capacity)
            : base(fuelQuantity, fuelConsumption, TruckAirConditioner, capacity)
        {

        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters * 0.95;
        }

    }
}
