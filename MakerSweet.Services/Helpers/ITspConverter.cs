using MakerSweet.Services.Models;

namespace MakerSweet.Services.Helpers
{
    public interface ITspConverter
    {
        //returns Constants.SUCCESS or Constants.FAILURE if tspFile was successfully created or not
        string ConvertCircleSVGtoTSP(string svgFileName);
        string ReorderSVGAccordingtoTSPsol(string fileToReorder,string tspSolFile);
    }
}
