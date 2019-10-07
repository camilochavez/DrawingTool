using DrawingTool.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeGenerator.Interface;
using ShapeGenerator.Service;

namespace ShapeGenerator.Test.Service
{
    [TestClass]
    public class RectangleServiceTest
    {
        private IShapeGenerator<Rectangle> _rectangleService;
        private Mock<IShapeGenerator<Line>> _lineGenerator;
        delegate void CreateShapeCallback(ref Canvas canvas_aux, Line line);

        [TestInitialize]
        public void RectangleService_TestInitialize()
        {
            _lineGenerator = new Mock<IShapeGenerator<Line>>();
            _rectangleService = new RectangleService(_lineGenerator.Object);
        }

        [TestMethod]
        public void RectangleService_CreateShape_Test()
        {
            // Given            
            Canvas canvas = new Canvas(4, 4);
            Rectangle rectangle = new Rectangle(new Point(1, 1), new Point(2, 2));
            _lineGenerator.Setup(lg => lg.CreateShape(ref canvas, It.IsAny<Line>())).Callback(new CreateShapeCallback((ref Canvas canvas_aux, Line line) =>
            {
                canvas_aux = canvas;
                canvas_aux.Matrix[1, 1] = 'x';
                canvas_aux.Matrix[1, 2] = 'x';
            }));            

            // When
            _rectangleService.CreateShape(ref canvas, rectangle);

            // Then
            Assert.AreEqual('\0', canvas.Matrix[0, 0]);
            Assert.AreEqual('\0', canvas.Matrix[0, 1]);
            Assert.AreEqual('\0', canvas.Matrix[0, 2]);
            Assert.AreEqual('\0', canvas.Matrix[1, 0]);
            Assert.AreEqual('\0', canvas.Matrix[2, 0]);
            Assert.AreEqual('x', canvas.Matrix[1, 1]);
            Assert.AreEqual('x', canvas.Matrix[1, 2]);
        }


        [TestMethod]
        public void RectangleService_CreateShape_NoMock_Test()
        {
            // Given            
            Canvas canvas = new Canvas(4, 4);
            Rectangle rectangle = new Rectangle(new Point(1, 1), new Point(2, 2));
            _rectangleService = new RectangleService(new LineService());
            
            // When
            _rectangleService.CreateShape(ref canvas, rectangle);

            // Then
            Assert.AreEqual('\0', canvas.Matrix[0, 0]);
            Assert.AreEqual('\0', canvas.Matrix[0, 1]);
            Assert.AreEqual('\0', canvas.Matrix[0, 2]);
            Assert.AreEqual('\0', canvas.Matrix[1, 0]);
            Assert.AreEqual('\0', canvas.Matrix[2, 0]);
            Assert.AreEqual('x', canvas.Matrix[1, 1]);
            Assert.AreEqual('x', canvas.Matrix[1, 2]);
            Assert.AreEqual('x', canvas.Matrix[2, 1]);
            Assert.AreEqual('x', canvas.Matrix[2, 2]);
        }
    }
}
