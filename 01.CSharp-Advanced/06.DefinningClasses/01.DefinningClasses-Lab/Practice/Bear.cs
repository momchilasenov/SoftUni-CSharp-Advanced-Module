using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Bear
    {
        //Properties - data
        public string Name { get; set; }

        public int DaysSinceLastMeal { get; set; }

        public int Age { get; set; }

        //Methods - behaviour
        public void Eat()
        {
            Console.WriteLine($"The bear {Name} just ate and is happy");
        }
    }
}
