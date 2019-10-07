namespace ShapeGenerator.Model
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Matrix { get; set; }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            Matrix = new char[height, width];
        }

    }
}
