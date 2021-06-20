using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfWeightNotInRange(string type, int minWeight, int maxWeight, int value)
        {
            if (value < minWeight ||
                    value > maxWeight)
            {
                throw new ArgumentException($"{type} weight should be in the range[{minWeight}..{maxWeight}].");
            }
        }

        public static void ThrowIfValuesNotPresent(HashSet<string> values, string value, string message)
        {
            if (!values.Contains(value))
            {
                throw new ArgumentException(message);
            }
        }


    }
}
