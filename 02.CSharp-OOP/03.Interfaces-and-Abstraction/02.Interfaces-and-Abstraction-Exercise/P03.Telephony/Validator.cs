using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public static class Validator
    {
        public static void ThrowIfInvalidNumber(string phoneNumber)
        {
            if (phoneNumber.Any(d => char.IsDigit(d) == false))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }

        public static void ThrowIfInvalidUrl(string url)
        {
            if (url.Any(l => char.IsDigit(l)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
        }
    }
}
