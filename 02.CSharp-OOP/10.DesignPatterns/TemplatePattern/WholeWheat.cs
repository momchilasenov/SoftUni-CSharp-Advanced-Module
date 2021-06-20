using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the wholewheat bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for wholewheat bread");
        }
    }
}
