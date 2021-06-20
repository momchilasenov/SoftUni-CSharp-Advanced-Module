using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BirthdayCelebrations
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
