using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BirthdayCelebrations
{
    public interface IPet : IBirthable
    {
        string Name { get; }
    }
}
