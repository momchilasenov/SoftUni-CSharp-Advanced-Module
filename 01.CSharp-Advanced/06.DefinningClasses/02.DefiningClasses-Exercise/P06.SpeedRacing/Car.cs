using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TraveledDistance { get; set; }

        public void DriveCar(double amountOfKm)
        {
            double usedFuel = amountOfKm * FuelConsumption;

            if (FuelAmount >= usedFuel)
            {
                FuelAmount -= usedFuel;
                TraveledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public void PrintCar()
        {
            Console.WriteLine($"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}");
        }


    }
}
