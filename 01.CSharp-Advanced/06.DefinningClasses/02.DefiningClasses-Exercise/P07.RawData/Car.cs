using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, int tire1Age, double tire1Pressure, int tire2Age, double tire2Pressure, int tire3Age, double tire3Pressure, int tire4Age, double tire4Pressure)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new Tire[]
            {
                new Tire(tire1Age, tire1Pressure),
                new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure),
                new Tire(tire4Age, tire4Pressure)
            };

        }

        public string Model { get; set; }

        public Tire[] Tires { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }
}
