using ShapeGenerator.Interface;
using ShapeGenerator.Model;

namespace ShapeGenerator.Service
{
    public class LineService : IShapeGenerator<Line>
    {
        const char x = 'x';
        public void CreateShape(ref Canvas canvas, Line shape)
        {
            canvas.Matrix[shape.Point1.Y, shape.Point1.X] = x;
            canvas.Matrix[shape.Point2.Y, shape.Point2.X] = x;
            if (shape.Point1.Y == shape.Point2.Y)
                for (int i = shape.Point1.X + 1; i <= shape.Point2.X; i++)
                    canvas.Matrix[shape.Point1.Y, i] = x;
            else if (shape.Point1.X == shape.Point2.X)
                for (int j = shape.Point1.Y + 1; j <= shape.Point2.Y; j++)
                    canvas.Matrix[j, shape.Point1.X] = x;
            else
                for (int k = shape.Point1.Y + 1; k <= shape.Point2.Y; k++)
                    canvas.Matrix[k, k] = x;
        }
    }
}
