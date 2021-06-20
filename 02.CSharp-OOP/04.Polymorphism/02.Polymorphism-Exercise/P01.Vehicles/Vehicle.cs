using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerModifier, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifier = airConditionerModifier;

        }

        private double AirConditionerModifier { get; set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                    return;
                }

                this.fuelQuantity = value;

            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            double requiredFuel = (this.FuelConsumption * distance) + (distance * this.AirConditionerModifier);

            if (requiredFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            this.FuelQuantity -= requiredFuel;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

    }
}
