using MakerSweet.Services.Models;

namespace MakerSweet.Services.Helpers
{
    public interface IStippler
    {
        string CallStippler(PngFile pngFile, SvgFile svgFile, int stipples, double sizingFactor);
    }
}
