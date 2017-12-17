using MakerSweet.Services.Models;
using System;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class GCodeCreator:IGcodeCreator
    {
        public string CreateCircularGCodeFile(SvgFile svgFile)
        {
            try
            {
                var gcodeFile = new GcodeFile($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{svgFile.FileName}");
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

                            }
                        }
                        gcodeWriter.WriteLine(gcodeFile.FileFooter);
                        Console.WriteLine($"The file {gcodeFile.FullFileName} has been created successfully");
                        return Constants.SUCCESS;
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"couldn't open file {svgFile.FullFileName}");
                Console.WriteLine(e.Message);
                return Constants.FAILURE;
            }
            
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
