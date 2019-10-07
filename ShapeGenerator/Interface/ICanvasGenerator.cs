using DrawingTool.Model.Model;

namespace ShapeGenerator.Interface
{
    public interface ICanvasGenerator
    {
        Canvas CreateCanvas(int width, int height);
    }
}
