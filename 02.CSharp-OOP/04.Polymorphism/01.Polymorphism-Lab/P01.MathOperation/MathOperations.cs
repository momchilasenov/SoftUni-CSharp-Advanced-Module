using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public double Add(double n1, double n2, double n3)
        {
            return n1 + n2 + n3;
        }

        public decimal Add(decimal d1, decimal d2, decimal d3)
        {
            return d1 + d2 + d3;
        }
    }
}
