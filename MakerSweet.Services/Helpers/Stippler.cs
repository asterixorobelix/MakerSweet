using MakerSweet.Services.Models;

/*
http://www.saliences.com/projects/npr/stippling/index.html

Must be a .png image file
must use command line. Navigate in command line to voronoi folder with executable in it. eg: C:\Users\8460p\Desktop\CNC\Stipplers\voronoi-20120413\voronoi 
Put PNG input file into folder.

In terminal: "voronoi -s 20000 -z 0.6 -n zumaPlatonCroppedResized.png zumaPlatonCroppedResized.svg"

Optional Parameters:
--no-overlap -n :Guarantees that stipple points will not overlap each other at the expense of some tone preservation. Defaults to OFF.
--fixed-radius -f :The radius of all stipple points will be equal regardless of the intensity of the input image. Defaults to OFF.
--sizing-factor -z :The radius of each stipple point will be multiplied by this factor. Use this parameter to control the tone preservation quality of the output image. Defaults to 1.0.
*/

namespace MakerSweet.Services.Helpers
{
    public class Stippler:IStippler
    {
        private const string _NOOVERLAP = "-n";
        private string svgName;
        private readonly string filepath = "C:\\Users\\8460p\\Desktop\\CNC\\Stipplers\\voronoi-20120413\\voronoi\\";

        public string GetConsoleCommand(PngFile pngFile, SvgFile svgFile, int stipples, double sizingFactor)
        {
            svgName = $"S{stipples}Z{sizingFactor}NoOverlap{svgFile.FullFileName}";
            return $"-s {stipples} -z {sizingFactor} {_NOOVERLAP} {filepath}{pngFile.FullFileName} {filepath}{svgName}";
        }
    }
}
