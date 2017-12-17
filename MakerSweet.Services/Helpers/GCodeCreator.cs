using MakerSweet.Services.Models;
using System;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class GCodeCreator:IGcodeCreator
    {
        public string CreateCircularGCodeFile(GcodeFile gcodeFile, TspFile tspFile)
        {
            try
            {
                using(StreamReader tspReader = new StreamReader(tspFile.FullFileName))
                {
                    using(StreamWriter gcodeWriter = new StreamWriter(gcodeFile.FullFileName))
                    {
                        gcodeWriter.WriteLine(gcodeFile.FileHeader);

                        while (tspReader.ReadLine() != null)
                        {
                            int res;
                            if(int.TryParse(tspReader.ReadLine().Substring(0,1),out res))
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
                Console.WriteLine($"couldn't open file {tspFile.FullFileName}");
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
