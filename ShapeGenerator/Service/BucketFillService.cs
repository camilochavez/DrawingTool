using DrawingTool.Model.Model;
using ShapeGenerator.Interface;

namespace ShapeGenerator.Service
{
    public class BucketFillService : IBucketFillGenerator
    {
        const char x = 'x';
        const char verticalChar = '|';
        const char horizontalChar = '-';
        public void FillCanvas(ref Canvas canvas, Point point, char color)
        {
            MoveToDown(ref canvas, point, color);
            MoveToUp(ref canvas, point, color);
        }


        private bool MoveToUp(ref Canvas canvas, Point point, char color)
        {
            if (!ValidatePoint(canvas, point))
                return false;
            MoveToRight(ref canvas, point, color);
            MoveToLeft(ref canvas, point, color);
            canvas.Matrix[point.Y, point.X] = color;
            MoveToUp(ref canvas, new Point(point.X, point.Y - 1), color);
            return true;
        }

        private bool MoveToDown(ref Canvas canvas, Point point, char color)
        {
            if (!ValidatePoint(canvas, point))
                return false;
            MoveToRight(ref canvas, point, color);
            MoveToLeft(ref canvas, point, color);
            canvas.Matrix[point.Y, point.X] = color;
            MoveToDown(ref canvas, new Point(point.X, point.Y + 1), color);
            return true;
        }

        private bool MoveToLeft(ref Canvas canvas, Point point, char color)
        {
            if (!ValidatePoint(canvas, point))
                return false;

            canvas.Matrix[point.Y, point.X] = color;
            MoveToLeft(ref canvas, new Point(point.X - 1, point.Y), color);
            return true;
        }

        private bool MoveToRight(ref Canvas canvas, Point point, char color)
        {
            if (!ValidatePoint(canvas, point))
                return false;

            canvas.Matrix[point.Y, point.X] = color;
            MoveToRight(ref canvas, new Point(point.X + 1, point.Y), color);
            return true;
        }
        private static bool ValidatePoint(Canvas canvas, Point point)
        {
            if (point.X <= 0 || point.X > canvas.Width - 1 ||
                point.Y <= 0 || point.Y > canvas.Height - 1 ||
                canvas.Matrix[point.Y, point.X] == x ||
                canvas.Matrix[point.Y, point.X] == verticalChar ||
                canvas.Matrix[point.Y, point.X] == horizontalChar)
                return false;
            return true;
        }
    }
}
