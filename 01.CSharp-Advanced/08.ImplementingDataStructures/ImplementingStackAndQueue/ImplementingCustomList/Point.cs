using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomList
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public static Point operator +(Point p1, Point p2)
        {//changing the operator + to return a new Point
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public int this[int i] //making a property for index operator
        {
            get
            {
                if (i == 0) //if index == 0 
                {
                    return this.X;
                }
                if (i == 1)
                {
                    return this.Y;
                }

                throw new IndexOutOfRangeException();
            }
        }
    }
}
