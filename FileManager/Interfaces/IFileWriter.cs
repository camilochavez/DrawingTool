using DrawingTool.Model;

namespace FileManager.Interfaces
{
    public interface IFileWriter
    {
        void DrawShapeIntoFile(Canvas canvas, string filePath);
        void ClearFile(string filePath);
    }
}
