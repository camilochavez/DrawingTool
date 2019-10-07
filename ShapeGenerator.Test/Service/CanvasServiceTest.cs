using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeGenerator.Interface;
using ShapeGenerator.Service;

namespace ShapeGenerator.Test.Service
{
    [TestClass]
    public class CanvasServiceTest
    {
        private ICanvasGenerator _canvasService;

        [TestInitialize]
        public void CanvasService_TestInitialize()
        {
            _canvasService = new CanvasService();
        }

        [TestMethod]
        public void CanvasService_CreateCanvas_Test()
        {
            //Given
            const int width = 2;
            const int height = 2;

            // When 
            var result = _canvasService.CreateCanvas(width, height);

            //Then
            Assert.AreEqual('-', result.Matrix[0, 0]);
            Assert.AreEqual('-', result.Matrix[0, 1]);
            Assert.AreEqual('-', result.Matrix[0, 2]);
            Assert.AreEqual('-', result.Matrix[0, 3]);
            Assert.AreEqual('-', result.Matrix[3, 0]);
            Assert.AreEqual('-', result.Matrix[3, 1]);
            Assert.AreEqual('-', result.Matrix[3, 2]);
            Assert.AreEqual('-', result.Matrix[3, 3]);
            Assert.AreEqual('|', result.Matrix[1, 0]);
            Assert.AreEqual('|', result.Matrix[2, 0]);          
            Assert.AreEqual('|', result.Matrix[1, 3]);
            Assert.AreEqual('|', result.Matrix[2, 3]);
            Assert.AreEqual('\0', result.Matrix[1, 1]);
            Assert.AreEqual('\0', result.Matrix[1, 2]);
            Assert.AreEqual('\0', result.Matrix[2, 1]);
            Assert.AreEqual('\0', result.Matrix[2, 2]);
        }
    }
}
