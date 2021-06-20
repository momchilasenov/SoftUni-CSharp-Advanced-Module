using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePerimiter();

        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return "Drawing";
        }
    }
}
