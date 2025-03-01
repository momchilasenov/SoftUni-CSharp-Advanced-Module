﻿using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Car audiCar = new Car("Audi", "A4", 120, "AB7865ES");
            //Parking parking = new Parking(4);
            //parking.Cars.Add(audiCar);
            //Console.WriteLine(parking.Cars.Count);
            //Console.WriteLine(parking.Cars.Capacity);
            //Car bmwCar = new Car("Bmw", "M3", 299, "AB7865ES");
            //parking.Cars.Add(bmwCar);
            //Console.WriteLine(parking.Cars.Capacity);

            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            //Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count); //1

            List<string> regNumbers = new List<string>();
            regNumbers.Add("EB8787MN");
            regNumbers.Add("EB8787MN");

            parking.RemoveSetOfRegistrationNumber(regNumbers);

        }
    }
}
