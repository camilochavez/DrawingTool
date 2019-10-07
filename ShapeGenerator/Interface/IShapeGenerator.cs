using ShapeGenerator.Model;

namespace ShapeGenerator.Interface
{
    public interface IShapeGenerator<T>
        where T : class
    {
        void CreateShape(ref Canvas canvas, T shape);
    }
}
