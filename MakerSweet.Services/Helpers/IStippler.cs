using MakerSweet.Services.Models;

namespace MakerSweet.Services.Helpers
{
    public interface IStippler
    {
        string GetConsoleCommand(PngFile pngFile, SvgFile svgFile, int stipples, double sizingFactor);
    }
}
