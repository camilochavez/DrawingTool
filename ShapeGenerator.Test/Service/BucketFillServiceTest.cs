using DrawingTool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeGenerator.Interface;
using ShapeGenerator.Service;

namespace ShapeGenerator.Test.Service
{
    [TestClass]
    public class BucketFillServiceTest
    {
        private IBucketFillGenerator _bucketFillGenerator;

        [TestInitialize]
        public void BucketFillService_TestInitialize()
        {
            _bucketFillGenerator = new BucketFillService();
        }

        [TestMethod]
        public void BucketFillService_FillCanvas_Test()
        {
            // Given 
            Canvas canvas = new Canvas(5, 5);
            canvas.Matrix[1, 0] = 'x';
            canvas.Matrix[1, 1] = 'x';
            canvas.Matrix[1, 2] = 'x';
            canvas.Matrix[1, 3] = 'x';
            canvas.Matrix[1, 4] = 'x';
            Point point = new Point(2, 2);
            const char color = 'c';

            // When
            _bucketFillGenerator.FillCanvas(ref canvas, point, color);

            // Then
            Assert.AreEqual('c', canvas.Matrix[2, 1]);
            Assert.AreEqual('c', canvas.Matrix[2, 2]);
            Assert.AreEqual('c', canvas.Matrix[2, 3]);
            Assert.AreEqual('c', canvas.Matrix[3, 1]);
            Assert.AreEqual('c', canvas.Matrix[3, 2]);
            Assert.AreEqual('c', canvas.Matrix[3, 3]);
            Assert.AreEqual('c', canvas.Matrix[4, 1]);
            Assert.AreEqual('c', canvas.Matrix[4, 2]);
            Assert.AreEqual('c', canvas.Matrix[4, 3]);
            Assert.AreEqual('x', canvas.Matrix[1, 1]);
            Assert.AreEqual('x', canvas.Matrix[1, 2]);
            Assert.AreEqual('x', canvas.Matrix[1, 3]);
            Assert.AreEqual('x', canvas.Matrix[1, 4]);
            Assert.AreEqual('x', canvas.Matrix[1, 3]);
            Assert.AreEqual('\0', canvas.Matrix[0, 0]);
            Assert.AreEqual('\0', canvas.Matrix[0, 1]);
            Assert.AreEqual('\0', canvas.Matrix[0, 2]);
            Assert.AreEqual('\0', canvas.Matrix[0, 3]);
            Assert.AreEqual('\0', canvas.Matrix[0, 4]);
        }
    }
}
