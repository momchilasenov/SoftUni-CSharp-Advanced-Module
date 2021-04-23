using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public double CalculateDays(string firstDate, string secondDate)
        {
            string[] firstInput = firstDate.Split();
            int year = int.Parse(firstInput[0]);
            int month = int.Parse(firstInput[1]);
            int day = int.Parse(firstInput[2]);

            DateTime first = new DateTime(year, month, day);

            string[] secondInput = secondDate.Split();
            int year2 = int.Parse(secondInput[0]);
            int month2 = int.Parse(secondInput[1]);
            int day2 = int.Parse(secondInput[2]);

            DateTime second = new DateTime(year2, month2, day2);

            return (first-second).TotalDays;

        }

    }
}
