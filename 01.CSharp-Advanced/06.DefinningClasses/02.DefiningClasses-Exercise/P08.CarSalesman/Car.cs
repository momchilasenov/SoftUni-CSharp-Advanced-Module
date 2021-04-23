using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        private string weight;
        private string color;

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight
        {
            get { return weight; }
            set
            {
                if (value == null)
                {
                    weight = "n/a";
                }
                else
                {
                    weight = value;
                }
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (value == null)
                {
                    color = "n/a";
                }
                else
                {
                    color = value;
                }
            }
        }
    }
}
