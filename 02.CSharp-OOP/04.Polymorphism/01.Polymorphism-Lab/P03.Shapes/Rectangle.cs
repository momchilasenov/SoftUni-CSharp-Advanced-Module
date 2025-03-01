﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.height = value;
            }

        }

        public double Width
        {
            get => this.width;
            private set
            {
                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;

        }

        public override double CalculatePerimiter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return $"{base.Draw()} {nameof(Rectangle)}";
        }
    }
}
