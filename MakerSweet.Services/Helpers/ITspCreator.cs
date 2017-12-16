using MakerSweet.Services.Models;

namespace MakerSweet.Services.Helpers
{
    public interface ITspCreator
    {
        //returns Constants.SUCCESS or Constants.FAILURE if tspFile was successfully created or not
        string ConvertCircleSVGtoTSP(SvgFile svgFile, TspFile tspFile);
    }
}
