﻿using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before.Drawers
{
    public class TriangleDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing Triangle");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Triangle;
        }
    }
}
