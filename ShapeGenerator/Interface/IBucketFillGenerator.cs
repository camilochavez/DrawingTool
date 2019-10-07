using ShapeGenerator.Model;

namespace ShapeGenerator.Interface
{
    public interface IBucketFillGenerator
    {
        void FillCanvas(ref Canvas canvas, Point point, char color);
    }
}
