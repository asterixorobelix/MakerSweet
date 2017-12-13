using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public interface IStippler
    {
        string GetConsoleCommand(PngFile pngFile, SvgFile svgFile, int stipples, double sizingFactor);
    }
}
