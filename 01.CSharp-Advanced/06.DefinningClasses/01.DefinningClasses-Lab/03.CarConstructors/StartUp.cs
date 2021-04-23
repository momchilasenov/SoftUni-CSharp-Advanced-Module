using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car defaultCar = new Car();
            Console.WriteLine(defaultCar.WhoAmI());

            Console.WriteLine();

            Car bmw = new Car("BMW", "M3", 2016);
            Console.WriteLine(bmw.WhoAmI());

            Console.WriteLine();

            Car audi = new Car("Audi", "A4", 2020, 200, 20);
            Console.WriteLine(audi.WhoAmI());

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}
