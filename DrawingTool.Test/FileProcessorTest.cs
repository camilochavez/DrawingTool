using System;
using System.Collections.Generic;
using System.Linq;
using FileManager.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeGenerator.Interface;
using ShapeGenerator.Model;

namespace DrawingTool.Test
{
    [TestClass]
    public class FileProcessorTest
    {
        private Mock<IFileReader> _fileReader;
        private Mock<IFileWriter> _fileWriter;
        private Mock<ICanvasGenerator> _canvasService;
        private Mock<IShapeGenerator<Line>> _lineService;
        private Mock<IShapeGenerator<Rectangle>> _rectangleService;
        private Mock<IBucketFillGenerator> _bucketFillGenerator;
        private IFileProcessor _fileProcessor;

        [TestInitialize]
        public void FileProcessor_TestInitialize()
        {
            _fileReader = new Mock<IFileReader>();
            _fileWriter = new Mock<IFileWriter>();
            _canvasService = new Mock<ICanvasGenerator>();
            _lineService = new Mock<IShapeGenerator<Line>>();
            _rectangleService = new Mock<IShapeGenerator<Rectangle>>();
            _bucketFillGenerator = new Mock<IBucketFillGenerator>();
            _fileProcessor = new FileProcessor(_fileReader.Object, _fileWriter.Object, _canvasService.Object, _lineService.Object, _rectangleService.Object, _bucketFillGenerator.Object);
        }

        [TestMethod]
        public void FileProcessor_ProcessFile_Test()
        {
            // Given
            const string fileInputPath = "Input Test Path";
            const string fileOutputPath = "Output Test Path";
            Canvas canvas = new Canvas(20, 4);
            List<Tuple<char, string[]>> parameters = new List<Tuple<char, string[]>>
            {
                Tuple.Create('C', new string[2] { "20", "4" }),
                Tuple.Create('L', new string[4] { "1", "2","6","2" }),
                Tuple.Create('R', new string[4] { "16", "1","20","3" }),
                Tuple.Create('B', new string[3] { "2", "3", "o" })
            };
            Line line = new Line(new Point(int.Parse(parameters[1].Item2[0]), int.Parse(parameters[1].Item2[1])),
                                                new Point(int.Parse(parameters[1].Item2[2]), int.Parse(parameters[1].Item2[3])));
            Rectangle rectangle = new Rectangle(new Point(int.Parse(parameters[2].Item2[0]), int.Parse(parameters[2].Item2[1])),
                                                       new Point(int.Parse(parameters[2].Item2[2]), int.Parse(parameters[2].Item2[3])));

            _fileReader.Setup(fr => fr.ReadFile(fileInputPath)).Returns(parameters);
            var canvasParameter = parameters.FirstOrDefault(p => p.Item1 == 'C');
            _canvasService.Setup(cs => cs.CreateCanvas(int.Parse(canvasParameter.Item2[0]), int.Parse(canvasParameter.Item2[1]))).Returns(canvas);
            _fileWriter.Setup(fw => fw.ClearFile(fileOutputPath));
            _fileWriter.Setup(fw => fw.DrawShapeIntoFile(canvas, fileOutputPath));
            _lineService.Setup(ls => ls.CreateShape(ref canvas, line));
            _rectangleService.Setup(rs => rs.CreateShape(ref canvas, rectangle));
            _bucketFillGenerator.Setup(bf => bf.FillCanvas(ref canvas, new Point(int.Parse(parameters[3].Item2[0]), int.Parse(parameters[3].Item2[1])),
                                                            char.Parse(parameters[3].Item2[2])));
            // When
            var result = _fileProcessor.ProcessFile(fileInputPath, fileOutputPath);

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FileProcessor_ProcessFile_NoCanvas_Test()
        {
            // Given
            const string fileInputPath = "Input Test Path";
            const string fileOutputPath = "Output Test Path";
            Canvas canvas = new Canvas(20, 4);
            List<Tuple<char, string[]>> parameters = new List<Tuple<char, string[]>>
            {
                Tuple.Create('L', new string[4] { "1", "2","6","2" }),
                Tuple.Create('R', new string[4] { "16", "1","20","3" }),
                Tuple.Create('B', new string[3] { "2", "3", "o" })
            };
            _fileReader.Setup(fr => fr.ReadFile(fileInputPath)).Returns(parameters);

            //when
            var result = _fileProcessor.ProcessFile(fileInputPath, fileOutputPath);

            // Then
            Assert.IsFalse(result);
        }
    }
}
