using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Calling(string phoneNumber)
        {
            Validator.ThrowIfInvalidNumber(phoneNumber);

            Console.WriteLine($"Dialing... {phoneNumber}");
        }
    }
}
