using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class GCodeCreator:IGcodeCreator
    {
        private readonly SvgFile svgFile;
        private readonly GcodeFile gcodeFile;

        public GCodeCreator(string svgFileName, double safeZHeight, double cutFeedRate, double plungeFeedRate, double depthPerPass, double finalDepth, double bitsize)
        {
            svgFile = new SvgFile(svgFileName);
            gcodeFile = new GcodeFile($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{svgFile.FileName}", safeZHeight, cutFeedRate, plungeFeedRate, depthPerPass, finalDepth, bitsize);
        }

        public string CreateCircularGCodeFile()
        {
            try
            {
                using(StreamReader svgReader = new StreamReader($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{svgFile.FullFileName}"))
                {
                    using(StreamWriter gcodeWriter = new StreamWriter($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{gcodeFile.FullFileName}"))
                    {
                        gcodeWriter.WriteLine(gcodeFile.FileHeader);

                        while (svgReader.ReadLine() != null)
                        {
                            string line = svgReader.ReadLine();
                            if(!line.Contains("circle"))
                            {
                                var CxCyR = new List<int>();
                                CxCyR = SVGParser.ParseCircleSVGLine(line);
                                gcodeWriter.WriteLine(MillCircle(gcodeFile, CxCyR));
                            }
                        }
                        gcodeWriter.WriteLine(gcodeFile.FileFooter);
                        return $"The file {gcodeFile.FullFileName} has been created successfully";
                    }
                }                
            }
            catch (Exception e)
            {
                return $"couldn't open file {svgFile.FileName}. {e.Message}";
            }            
        }

        //finish this
        public static string MillCircle(GcodeFile gcodeFile, List<int> xyR)
        {
            //Rapid position to XY location
            var str1 =Mach3GcodeCommands.RapidMoveToXYLocation(gcodeFile.SafeZHeight, xyR[0], xyR[1]);

            var iterations = GetIterations(gcodeFile.FinalDepth, gcodeFile.DepthPerPass);

            return str1 + iterations;
        }

        public static int GetIterations(double finalDepth, double depthPerPass)
        {
            return (int)Math.Round(finalDepth / depthPerPass, 0, MidpointRounding.AwayFromZero);
        }
    }
}
