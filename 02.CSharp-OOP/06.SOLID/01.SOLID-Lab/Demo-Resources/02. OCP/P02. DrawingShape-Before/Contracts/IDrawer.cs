namespace P02._DrawingShape_Before.Contracts
{
    interface IDrawer
    {
        //everything that's IDrawer knows if it can draw a given shape and then has a method for Drawing it

        void Draw(IShape shape);

        bool IsMatch(IShape shape);
    }
}
