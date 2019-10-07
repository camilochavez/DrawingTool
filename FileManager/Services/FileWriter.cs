using DrawingTool.Model.Model;
using FileManager.Interfaces;
using System.Text;

namespace FileManager.Services
{
    public class FileWriter : IFileWriter
    {
        public void ClearFile(string filePath)
        {
            System.IO.File.WriteAllText(filePath, string.Empty);
        }

        public void DrawShapeIntoFile(Canvas canvas, string filePath)
        {
            StringBuilder textCanvas = new StringBuilder();
            for (int i = 0; i < canvas.Height; i++)
            {
                for (int j = 0; j < canvas.Width; j++)
                {
                    textCanvas.Append(canvas.Matrix[i, j] == '\0' ? ' ' : canvas.Matrix[i, j]);
                }
                textCanvas.AppendLine();
            }
            System.IO.File.AppendAllText(filePath, textCanvas.ToString());
        }
    }
}
