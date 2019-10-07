using DrawingTool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeGenerator.Interface;
using ShapeGenerator.Service;

namespace ShapeGenerator.Test.Service
{
    [TestClass]
    public class LineServiceTest
    {
        private IShapeGenerator<Line> _lineService;

        [TestInitialize]
        public void LineService_TestInitialize()
        {
            _lineService = new LineService();
        }

        [TestMethod]
        public void LineService_CreateShape_Horizontal_Test()
        {
            //Given
            Canvas canvas = new Canvas(4, 4);
            Line line = new Line(new Point(1, 1), new Point(2, 1));

            //When
            _lineService.CreateShape(ref canvas, line);

            //Then
            Assert.AreEqual('x', canvas.Matrix[1, 1]);
            Assert.AreEqual('x', canvas.Matrix[1, 2]);
            Assert.AreEqual('\0', canvas.Matrix[2, 1]);
            Assert.AreEqual('\0', canvas.Matrix[2, 2]);
        }

        [TestMethod]
        public void LineService_CreateShape_Vertical_Test()
        {
            //Given
            Canvas canvas = new Canvas(4, 4);
            Line line = new Line(new Point(1, 1), new Point(1, 2));

            //When
            _lineService.CreateShape(ref canvas, line);

            //Then
            Assert.AreEqual('x', canvas.Matrix[1, 1]);
            Assert.AreEqual('x', canvas.Matrix[2, 1]);
            Assert.AreEqual('\0', canvas.Matrix[1, 2]);
            Assert.AreEqual('\0', canvas.Matrix[2, 2]);
        }


        [TestMethod]
        public void LineService_CreateShape_Diagonal_Test()
        {
            //Given
            Canvas canvas = new Canvas(4, 4);
            Line line = new Line(new Point(1, 1), new Point(2, 2));

            //When
            _lineService.CreateShape(ref canvas, line);

            //Then
            Assert.AreEqual('x', canvas.Matrix[1, 1]);
            Assert.AreEqual('x', canvas.Matrix[2, 2]);
            Assert.AreEqual('\0', canvas.Matrix[1, 2]);
            Assert.AreEqual('\0', canvas.Matrix[2, 1]);
        }
    }
}
