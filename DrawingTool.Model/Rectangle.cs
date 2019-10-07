namespace DrawingTool.Model
{
    public class Rectangle : Shape
    {
        public Rectangle(int x1, int y1, int x2, int y2) : base(x1, x2, y1, y2)
        {

        }

        public Rectangle(Point point1, Point point2) : base(point1, point2)
        {

        }
    }
}
