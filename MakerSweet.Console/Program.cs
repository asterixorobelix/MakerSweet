using MakerSweet.Services;
using MakerSweet.Services.Models;
using System;

namespace MakerSweet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new File("f");
            var svg = new SvgFile("s");
            var tsp = new TspFile("t");
        }
    }
}
