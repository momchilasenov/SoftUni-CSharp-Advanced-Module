using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int comfort = 1;
        private const int price = 5;

        public Ornament() 
            : base(comfort, price)
        {
        }
    }
}
