namespace P02._DrawingShape_Before

{
    using Contracts;
    using System.Linq;
    using System.Collections.Generic;
    using P02._DrawingShape_Before.Drawers;


    class DrawingManager
    {
        private List<IDrawer> drawers = new List<IDrawer>()
        {
            new CircleDrawer(),
            new RectangleDrawer(),
            new TriangleDrawer(),
            new LineDrawer()
        };

        public void Draw(IShape shape)
        {
            IDrawer drawer = drawers.First(d => d.IsMatch(shape));
            drawer.Draw(shape);
        }
    }
}
