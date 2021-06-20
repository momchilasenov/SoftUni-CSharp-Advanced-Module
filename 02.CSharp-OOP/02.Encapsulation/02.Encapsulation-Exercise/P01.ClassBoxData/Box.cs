using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Length));

                this.length = value;

            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Width));

                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Height));

                this.height = value;
            }
        }
                

        public double GetSurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
        }

        public double GetLateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return 2 * this.length * this.height + 2 * this.width * this.height;
        }

        public double GetVolume()
        {
            //Volume = lwh
            return this.length * this.width * this.height;
        }

        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }

    }
}
