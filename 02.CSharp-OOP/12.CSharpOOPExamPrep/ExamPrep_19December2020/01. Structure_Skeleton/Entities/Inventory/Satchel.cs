﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        public Satchel() 
            : base(20)
        {
        }
    }
}
