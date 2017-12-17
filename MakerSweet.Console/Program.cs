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
            var svg = new SvgFile("S1000Z0point8NoOverlapColorTattooPNGFile");
            var tsp = new TspFile(filename);
            var tspSol = new TspSolFile("S1000Z0point8NoOverlapColorTattooPNGFile");
            tsp.Dimension = 1000;

            //var stipplerServices = serviceProvider.GetRequiredService<IStippler>();
            //Console.WriteLine(stipplerServices.CallStippler(png, 1000, 0.8));

            var tspServices = serviceProvider.GetRequiredService<ITspConverter>();
            //Console.WriteLine(tspServices.ConvertCircleSVGtoTSP(svg));

            Console.WriteLine(tspServices.ReorderSVGAccordingtoTSPsol(svg, tspSol, tsp));

            Console.Read();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<IStippler, Stippler>();
            serviceCollection.AddTransient<ITspConverter, TspConverter>();
        }
    }
}
