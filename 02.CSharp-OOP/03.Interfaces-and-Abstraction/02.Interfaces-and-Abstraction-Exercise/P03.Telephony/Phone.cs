using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public abstract class Phone : ICallable
    {
        public abstract void Calling(string phoneNumber);
    }
}
