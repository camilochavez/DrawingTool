using DrawingTool.Model;

namespace ShapeGenerator.Interface
{
    public interface ICanvasGenerator
    {
        Canvas CreateCanvas(int width, int height);
    }
}
