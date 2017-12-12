using MakerSweet.Services;
using MakerSweet.Services.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using MakerSweet.Services.Helpers;

namespace MakerSweet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var fileServices = serviceProvider.GetRequiredService<IStippler>();

            var file = new File("f");
            var svg = new SvgFile("s");
            var tsp = new TspFile("t");
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<IStippler, Stippler>();
            serviceCollection.AddTransient<ITspCreator, TspCreator>();
        }
    }
}
