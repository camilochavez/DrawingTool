using ShapeGenerator.Interface;
using ShapeGenerator.Model;

namespace ShapeGenerator.Service
{
    public class RectangleService : IShapeGenerator<Rectangle>
    {
        private readonly IShapeGenerator<Line> _lineGenerator;
        public RectangleService(IShapeGenerator<Line> lineGenerator)
        {
            _lineGenerator = lineGenerator;
        }
        public void CreateShape(ref Canvas canvas, Rectangle shape)
        {
            _lineGenerator.CreateShape(ref canvas, new Line(shape.Point1, new Point(shape.Point2.X, shape.Point1.Y)));
            _lineGenerator.CreateShape(ref canvas, new Line(shape.Point1, new Point(shape.Point1.X, shape.Point2.Y)));
            _lineGenerator.CreateShape(ref canvas, new Line(new Point(shape.Point1.X, shape.Point2.Y), shape.Point2));
            _lineGenerator.CreateShape(ref canvas, new Line(new Point(shape.Point2.X, shape.Point1.Y), shape.Point2));
        }
    }
}
