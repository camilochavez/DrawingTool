namespace DrawingTool.Model.Model
{
    public class Line : Shape
    {
        public Line(int x1, int y1, int x2, int y2) : base(x1, x2, y1, y2)
        {

        }

        public Line(Point point1, Point point2) : base(point1, point2)
        {

        }

    }
}
