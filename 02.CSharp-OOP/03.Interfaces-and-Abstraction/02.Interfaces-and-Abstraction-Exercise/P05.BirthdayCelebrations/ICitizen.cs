using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BirthdayCelebrations
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        string Name { get; }

        int Age { get; }
    }
}
