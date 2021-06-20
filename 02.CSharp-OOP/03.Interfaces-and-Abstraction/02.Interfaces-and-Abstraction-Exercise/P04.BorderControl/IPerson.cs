using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IPerson : IIdentifiable
    {
        string Name { get; }

        int Age { get; }

    }
}
