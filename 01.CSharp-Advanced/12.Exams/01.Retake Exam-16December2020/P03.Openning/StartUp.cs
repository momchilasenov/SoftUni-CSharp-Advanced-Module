using System;

namespace BakeryOpenning
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Bakery bakery = new Bakery("Barny", 3);

            Employee employee = new Employee("Stephen", 40, "Bulgaria");
            Employee employee2 = new Employee("Mia", 15, "Bulgaria");
            Employee employee3= new Employee("Lara", 25, "Bulgaria");
            Employee employee4 = new Employee("Sasha", 16, "Bulgaria");

            bakery.Add(employee);
            bakery.Add(employee2);
            bakery.Add(employee3);
            bakery.Add(employee4);

            Console.WriteLine(bakery.Report());

            Console.WriteLine(bakery.GetOldestEmployee());
            Console.WriteLine(bakery.GetEmployee("Lara"));

            Console.WriteLine(bakery.Remove("Sasha"));
            Console.WriteLine(bakery.Remove("Mia"));

            Console.WriteLine(bakery.Report());
        }
    }
}
