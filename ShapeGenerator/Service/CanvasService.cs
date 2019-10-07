using ShapeGenerator.Interface;
using ShapeGenerator.Model;

namespace ShapeGenerator.Service
{
    public class CanvasService : ICanvasGenerator
    {
        const char verticalChar = '|';
        const char horizontalChar = '-';
        public Canvas CreateCanvas(int width, int height)
        {
            Canvas canvas = new Canvas(width + 2, height + 2);
            for (int i = 0; i < canvas.Height; i++)
            {
                for (int j = 0; j < canvas.Width; j++)
                {
                    if (j == 0 || j == canvas.Width - 1)
                        canvas.Matrix[i, j] = verticalChar;

                    if (i == 0 || i == canvas.Height - 1)
                        canvas.Matrix[i, j] = horizontalChar;
                }
            }
            return canvas;
        }
    }
}
