using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string url)
        {
            Validator.ThrowIfInvalidUrl(url);
            
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Calling(string phoneNumber)
        {
            Validator.ThrowIfInvalidNumber(phoneNumber);

            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
