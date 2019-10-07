using DrawingTool.Model;
using FileManager.Interfaces;
using FileManager.Services;
using Microsoft.Extensions.DependencyInjection;
using ShapeGenerator.Interface;
using ShapeGenerator.Service;

namespace DrawingTool
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddSingleton<ICanvasGenerator, CanvasService>();
            services.AddSingleton<IShapeGenerator<Line>, LineService>();
            services.AddSingleton<IShapeGenerator<Rectangle>, RectangleService>();
            services.AddSingleton<IBucketFillGenerator, BucketFillService>();
            services.AddSingleton<IFileWriter, FileWriter>();
            services.AddSingleton<IFileReader, FileReader>();
            services.AddSingleton<IFileProcessor, FileProcessor>();
            return services;
        }
    }
}
