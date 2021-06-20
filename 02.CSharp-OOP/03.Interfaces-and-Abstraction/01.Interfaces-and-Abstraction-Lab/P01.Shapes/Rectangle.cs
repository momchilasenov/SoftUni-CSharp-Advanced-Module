using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get => this.width;
            set { this.width = value; }
        }

        public int Height
        {
            get => this.height;
            set { this.height = value; }
        }

        public void Draw()
        {
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    if (row == 0 || row == this.height - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        if (col == 0 || col == this.width - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
