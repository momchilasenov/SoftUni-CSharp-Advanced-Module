using System;
using System.Collections.Generic;
using System.Text;
using P02._DrawingShape_Before.Contracts;


namespace P02._DrawingShape_Before.Drawers
{
    class LineDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing line");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Line;
        }
    }
}
