using MakerSweet.Services;
using MakerSweet.Services.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using MakerSweet.Services.Helpers;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace MakerSweet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var filename = "ColorTattooPNGFile";
            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var svg = new SvgFile(filename);

            var png = new PngFile(filename);

            var fileServices = serviceProvider.GetRequiredService<IStippler>();
            var command = fileServices.GetConsoleCommand(png,svg,10,1);
            var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            string[] fileArray = Directory.GetFiles(currentDirectory);
            ProcessStartInfo startInfo = new ProcessStartInfo($"{currentDirectory}voronoi.exe", command);
            Console.WriteLine(startInfo);
            Process p = Process.Start(startInfo);
            p.WaitForExit();
            Console.Read();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<IStippler, Stippler>();
            serviceCollection.AddTransient<ITspCreator, TspCreator>();
        }
    }
}
