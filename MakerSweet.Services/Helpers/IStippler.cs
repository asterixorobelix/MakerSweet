using MakerSweet.Services.Models;

namespace MakerSweet.Services.Helpers
{
    public interface IStippler
    {
        string CallStippler(PngFile pngFile, int stipples, double sizingFactor);
    }
}
