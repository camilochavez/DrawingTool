using FileManager.Interfaces;
using FileManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FileManager.Test
{
    [TestClass]
    public class FileReaderTest
    {
        private IFileReader _fileReader;

        [TestInitialize]
        public void FileReader_TestInitialize() {
            _fileReader = new FileReader();
        }

        [TestMethod]
        public void FileReader_ReadFile_Test()
        {
            // Given
            string inputFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{@"\Resource\InputTest.txt"}";

            // When
            var result =_fileReader.ReadFile(inputFilePath);

            // Then
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result.FirstOrDefault().Item1.Equals('C'));
            Assert.IsTrue(result.ToArray()[1].Item1.Equals('L'));
            Assert.IsTrue(result.ToArray()[2].Item1.Equals('L'));
            Assert.IsTrue(result.ToArray()[3].Item1.Equals('R'));
            Assert.IsTrue(result.ToArray()[4].Item1.Equals('B'));
        }
    }
}
