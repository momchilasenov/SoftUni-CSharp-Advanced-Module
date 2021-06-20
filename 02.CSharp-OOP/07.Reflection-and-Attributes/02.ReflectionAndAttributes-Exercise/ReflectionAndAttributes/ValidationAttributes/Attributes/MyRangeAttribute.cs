using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        private bool inclusive;

        public MyRangeAttribute(int minValue, int maxValue, bool inclusive = true)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.inclusive = inclusive;
        }

        public override bool IsValid(object obj)
        {
            int number = (int)obj;

            if (this.inclusive)
            {
                return number >= this.minValue && number <= this.maxValue;
            }

            return number > this.minValue && number < this.maxValue;


        }
    }
}
