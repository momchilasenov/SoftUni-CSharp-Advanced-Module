using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditioner = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double capacity)
            :base(fuelQuantity, fuelConsumption, CarAirConditioner, capacity)
        {

        }
    }
}
