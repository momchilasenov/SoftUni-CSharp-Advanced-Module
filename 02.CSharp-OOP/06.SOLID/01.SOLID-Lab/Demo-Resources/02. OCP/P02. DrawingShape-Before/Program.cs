using System;

namespace P02._DrawingShape_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawingManager drawer = new DrawingManager();

            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();

            drawer.Draw(circle);
            drawer.Draw(rectangle);
        }
    }
}
