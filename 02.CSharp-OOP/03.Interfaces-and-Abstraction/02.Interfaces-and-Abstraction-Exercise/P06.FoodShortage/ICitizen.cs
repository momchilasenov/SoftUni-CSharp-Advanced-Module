﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface ICitizen : IPerson
    {
        string Id { get; }

        string Birthdate { get; }
    }
}
