using MakerSweet.Services;
using MakerSweet.Services.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using MakerSweet.Services.Helpers;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

/*
 * https://www.ofoct.com/viewer/svg-viewer-online.html
 * */

namespace MakerSweet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency injection setup beigns
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            //Dependency injection setup ends

            var filename = "ColorTattooPNGFile";
            var png = new PngFile(filename);
            var svg = new SvgFile(filename);            

            var fileServices = serviceProvider.GetRequiredService<IStippler>();
            var command = fileServices.GetConsoleCommand(png,svg,1000,0.7);

            //string[] voronoifiles = Directory.GetFiles("..\\Voronoi");
            //foreach (var file in voronoifiles)
            //{
            //    Console.WriteLine(file);
            //}
            ProcessStartInfo startInfo = new ProcessStartInfo("..\\Voronoi\\voronoi.exe", command);
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
