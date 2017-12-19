using MakerSweet.Services.Models;

namespace MakerSweet.Services.Helpers
{
    public interface IStippler
    {
        string CallStippler(string pngFileName, int stipples, double sizingFactor);
    }
}
