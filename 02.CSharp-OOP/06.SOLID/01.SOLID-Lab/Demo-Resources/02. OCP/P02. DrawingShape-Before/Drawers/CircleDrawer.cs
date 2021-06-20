using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before.Drawers
{
    public class CircleDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing Circle");
        }

        public bool IsMatch(IShape shape)
        { //if the shape is circle - the circleDrawer can draw it

            return shape is Circle;
        }

    }
}
