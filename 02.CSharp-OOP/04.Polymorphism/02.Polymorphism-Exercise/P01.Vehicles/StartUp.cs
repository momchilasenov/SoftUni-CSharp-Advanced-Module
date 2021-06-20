using System;

namespace P01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                string type = commands[1];
                double parameter = double.Parse(commands[2]);

                try
                {
                    if (type == nameof(Car))
                    {
                        ProcessCommand(car, command, parameter);
                    }
                    else if (type == nameof(Truck))
                    {
                        ProcessCommand(truck, command, parameter);
                    }
                    else if (type == nameof(Bus))
                    {
                        ProcessCommand(bus, command, parameter);
                    }
                }
                catch (Exception ex)
                when(ex is InvalidOperationException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static void ProcessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);
            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(parameter);
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] data = Console.ReadLine().Split();

            string vehicleType = data[0];
            double fuel = double.Parse(data[1]);
            double consumption = double.Parse(data[2]);
            double capacity = double.Parse(data[3]);

            Vehicle vehicle = null;

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuel, consumption, capacity);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuel, consumption, capacity);
            }
            else if (vehicleType == nameof(Bus))
            {
                vehicle = new Bus(fuel, consumption, capacity);
            }

            return vehicle;
        }
    }
}
