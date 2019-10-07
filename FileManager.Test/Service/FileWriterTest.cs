using DrawingTool.Model.Model;
using FileManager.Interfaces;
using FileManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace FileManager.Test.Service
{
    [TestClass]
    public class FileWriterTest
    {
        private IFileWriter _fileWriter;

        [TestInitialize]
        public void FileWriter_TestInitialize()
        {
            _fileWriter = new FileWriter();
        }
        [TestMethod]
        public void FileWriter_DrawShapeIntoFile_Test()
        {
            // Given
            string outputFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{@"\Resource\OutputTest.txt"}";
            string templateFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{@"\Resource\OutputTemplateTest.txt"}";
            Canvas canvas = new Canvas(4, 4);
            canvas.Matrix[0, 0] = '-';
            canvas.Matrix[0, 1] = '-';
            canvas.Matrix[0, 2] = '-';
            canvas.Matrix[0, 3] = '-';
            canvas.Matrix[3, 0] = '-';
            canvas.Matrix[3, 1] = '-';
            canvas.Matrix[3, 2] = '-';
            canvas.Matrix[3, 3] = '-';
            canvas.Matrix[1, 0] = '|';
            canvas.Matrix[2, 0] = '|';
            canvas.Matrix[1, 3] = '|';
            canvas.Matrix[2, 3] = '|';

            // When
            _fileWriter.DrawShapeIntoFile(canvas, outputFilePath);

            //Then
            Assert.IsTrue(CompareFiles(outputFilePath, templateFilePath));
        }

        [TestMethod]
        public void FileWriter_Clear_Test()
        {
            // Given
            string outputFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{@"\Resource\OutputTest.txt"}";

            //When
            _fileWriter.ClearFile(outputFilePath);

            // Then
            var bytesResult = File.ReadAllBytes(outputFilePath);
            Assert.AreEqual(0, bytesResult.Length);
        }

        private bool CompareFiles(string outputFilePath, string templateFilePath)
        {
            byte[] file1 = File.ReadAllBytes(outputFilePath);
            byte[] file2 = File.ReadAllBytes(templateFilePath);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
