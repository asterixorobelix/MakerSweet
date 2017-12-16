using MakerSweet.Services.Models;
using System;
using System.Diagnostics;

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
        private readonly string filepath = Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH;

        private string GetConsoleCommand(string pngFileName, string svgFileName, int stipples, double sizingFactor)
        {
            var svgName = $"S{stipples}Z{Convert.ToString(sizingFactor).Replace(".","point")}NoOverlap{svgFileName}";
            return $"-s {stipples} -z {sizingFactor} {_NOOVERLAP} {filepath}{pngFileName} {filepath}{svgName}";
        }

        public string CallStippler(PngFile pngFile, int stipples, double sizingFactor)
        {
            var svgFile = new SvgFile(pngFile.FileName);
            var command = GetConsoleCommand(pngFile.FullFileName, svgFile.FullFileName, stipples, sizingFactor);
            var startInfo = new ProcessStartInfo(Constants.VORONOI_RELATIVE_PATH, command);
            var p = Process.Start(startInfo);
            p.WaitForExit();
            return Constants.SUCCESS;
        }
    }
}
