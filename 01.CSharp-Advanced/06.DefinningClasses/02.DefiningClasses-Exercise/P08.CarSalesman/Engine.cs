using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Engine
    {
        private string displacement;
        private string efficiency;

        public string Model { get; set; }

        public int Power { get; set; }

        public string Displacement
        {
            get { return displacement; }
            set
            {
                if (value == null)
                {
                    displacement = "n/a";
                }
                else
                {
                    displacement = value;
                }
            }
        }


        public string Efficiency
        {
            get { return efficiency; }
            set 
            {
                if (value == null)
                {
                    efficiency = "n/a";
                }
                else
                {
                    efficiency = value;
                }
            }
        }
    }
}
