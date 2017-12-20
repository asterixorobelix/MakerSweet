using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class GCodeCreator:IGcodeCreator
    {
        public string CreateCircularGCodeFile(string svgFileName, double safeZHeight)
        {
            try
            {
                var svgFile = new SvgFile(svgFileName);
                var gcodeFile = new GcodeFile($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{svgFile.FileName}", safeZHeight);
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
                                ConvertCircleSVGLineToGCode(line);
                            }
                        }
                        gcodeWriter.WriteLine(gcodeFile.FileFooter);
                        return $"The file {gcodeFile.FullFileName} has been created successfully";
                    }
                }
                
            }
            catch (Exception e)
            {
                return $"couldn't open file {svgFileName}. {e.Message}";
            }
            
        }

        private List<int> ConvertCircleSVGLineToGCode(string line)
        {
            string[] coords = line.Split("=");
            var CxCyR = new List<int>();
            if (coords.Length != 0)
            {
                int parsedResult;                
                int.TryParse(coords[0],out parsedResult);
                CxCyR.Add(parsedResult);
                int.TryParse(coords[1], out parsedResult);
                CxCyR.Add(parsedResult);
                int.TryParse(coords[2], out parsedResult);
                CxCyR.Add(parsedResult);
            }
            return CxCyR;
        }

        private static string FeedRate(double feed)
        {
            return $"F{feed}{Environment.NewLine}";
        }
        private static string RapidMove(double z)
        {
            //G00 = Rapid positioning
            return $"G0 Z{z}{Environment.NewLine}";
        }
        private static string RapidMove(double x, double y)
        {
            //G00 = Rapid positioning
            return $"G0 X{x} Y{y}{Environment.NewLine}";
        }

        private static string RapidMove(double x, double y, double z)
        {
            //G00 = Rapid positioning
            return $"G0 X{x} Y{y} Z{z}{Environment.NewLine}";
        }

        private static string ClockWiseArc(double i)
        {
            return $"G2 I{i}{Environment.NewLine}";
        }
    }
}
