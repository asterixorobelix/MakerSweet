using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class GCodeCreator:IGcodeCreator
    {
        public SvgFile svgFile {private get; set; }
        public GcodeFile gcodeFile {private get; set; }

        public string svgFileName { private get; set; }
        public double safeZHeight { private get; set; }
        public double cutFeedRate { private get; set; }
        public double plungeFeedRate { private get; set; }
        public double depthPerPass { private get; set; }
        public double finalDepth { private get; set; }
        public double bitsize { private get; set; }

        public string CreateCircularGCodeFile()
        {
            try
            {
                svgFile = new SvgFile(svgFileName);
                gcodeFile = new GcodeFile(svgFile.FileName, safeZHeight, cutFeedRate, plungeFeedRate, depthPerPass, finalDepth, bitsize);
                using (StreamReader svgReader = new StreamReader($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{svgFile.FullFileName}"))
                {
                    using(StreamWriter gcodeWriter = new StreamWriter($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{gcodeFile.FullFileName}"))
                    {
                        gcodeWriter.WriteLine(gcodeFile.FileHeader);

                        while (svgReader.ReadLine() != null)
                        {
                            string line = svgReader.ReadLine();
                            if(line.Contains("circle"))
                            {
                                var CxCyR = new List<double>();
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
        public static string MillCircle(GcodeFile gcodeFile, List<double> xyR)
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
