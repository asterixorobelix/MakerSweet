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
                                var CxCyR = new List<int>();
                                CxCyR = SVGParser.ParseCircleSVGLine(line);
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
    }
}
