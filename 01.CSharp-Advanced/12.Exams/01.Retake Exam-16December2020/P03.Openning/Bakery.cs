using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Employee employee)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            foreach (var employee in data)
            {
                if (employee.Name == name)
                {
                    data.Remove(employee);
                    return true;
                }
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.Where(e => e.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            sb.AppendLine($"{string.Join(Environment.NewLine, data)}");
            return sb.ToString().TrimEnd();
        }



    }
}
