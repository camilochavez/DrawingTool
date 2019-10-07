using FileManager.Interfaces;
using ShapeGenerator.Interface;
using ShapeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingTool
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly ICanvasGenerator _canvasService;
        private readonly IShapeGenerator<Line> _lineService;
        private readonly IShapeGenerator<Rectangle> _rectangleService;
        private readonly IBucketFillGenerator _bucketFillService;

        public FileProcessor(IFileReader fileReader, IFileWriter fileWriter, ICanvasGenerator canvasService,
                            IShapeGenerator<Line> lineService, IShapeGenerator<Rectangle> rectangleService,
                            IBucketFillGenerator bucketFillService)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _canvasService = canvasService;
            _lineService = lineService;
            _rectangleService = rectangleService;
            _bucketFillService = bucketFillService;

        }

        public bool ProcessFile(string fileInputPath, string fileOutputPath)
        {
            Canvas canvas;
            List<Tuple<char, string[]>> parameters = _fileReader.ReadFile(fileInputPath);
            if (!parameters.Any(p => p.Item1 == 'C'))
            {
                Console.WriteLine("There is no canvas in the input file");
                return false;
            }
            else
            {
                var canvasParameter = parameters.FirstOrDefault(p => p.Item1 == 'C');
                canvas = _canvasService.CreateCanvas(int.Parse(canvasParameter.Item2[0]), int.Parse(canvasParameter.Item2[1]));
                parameters.Remove(canvasParameter);
                _fileWriter.ClearFile(fileOutputPath);
                _fileWriter.DrawShapeIntoFile(canvas, fileOutputPath);
            }

            foreach (var parameter in parameters)
            {
                switch (parameter.Item1)
                {
                    case 'L':
                        {
                            Line line = new Line(new Point(int.Parse(parameter.Item2[0]), int.Parse(parameter.Item2[1])),
                                                 new Point(int.Parse(parameter.Item2[2]), int.Parse(parameter.Item2[3])));
                            _lineService.CreateShape(ref canvas, line);
                            _fileWriter.DrawShapeIntoFile(canvas, fileOutputPath);
                        }
                        break;
                    case 'R':
                        {
                            Rectangle rectangle = new Rectangle(new Point(int.Parse(parameter.Item2[0]), int.Parse(parameter.Item2[1])),
                                                           new Point(int.Parse(parameter.Item2[2]), int.Parse(parameter.Item2[3])));
                            _rectangleService.CreateShape(ref canvas, rectangle);
                            _fileWriter.DrawShapeIntoFile(canvas, fileOutputPath);
                        }
                        break;
                    case 'B':
                        {
                            _bucketFillService.FillCanvas(ref canvas,
                                                            new Point(int.Parse(parameter.Item2[0]), int.Parse(parameter.Item2[1])),
                                                            char.Parse(parameter.Item2[2]));
                            _fileWriter.DrawShapeIntoFile(canvas, fileOutputPath);
                        }
                        break;
                }
            }
            return true;
        }
    }
}
