using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the sourdough bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for sourdough bread");
        }
    }
}
