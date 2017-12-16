using MakerSweet.Services.Models;
using System;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class TspCreator:ITspCreator
    {
        private const string CX = "cx";
        private const string CY = "cy";
        private const string R = "r";
        private readonly string filepath = Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH;

        public string ConvertCircleSVGtoTSP(SvgFile svgFile, TspFile tspFile)
        {
            tspFile.Dimension = GetSvgFileCircleLineCount(svgFile);//TSP file must contain information regarding how many circles that there are in the svgfile

            int XwordStart, XwordEnd, YwordStart, YwordEnd;

            if (tspFile.Dimension != 0)
            {
                try
                {
                    tspFile.SvgFileName = svgFile.FullFileName;
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader svgReader = new StreamReader($"{filepath}{svgFile.FullFileName}"))
                    {

                        using (StreamWriter tspWriter = new StreamWriter($"{filepath}{tspFile.FullFileName}"))
                        {
                            //populate tspfile header
                            tspWriter.WriteLine(TspFile.GetFileHeader(tspFile));

                            var count = 1;

                            string line;
                            // Read and display lines from the file until the end of 
                            // the file is reached.
                            while ((line = svgReader.ReadLine()) != null)
                            {
                                if (line.Contains("circle"))
                                {
                                    tspWriter.Write(count + " ");
                                    XwordStart = line.IndexOf(CX) + CX.Length + 2;
                                    XwordEnd = line.IndexOf(CY, XwordStart);

                                    tspWriter.Write(line.Substring(XwordStart, XwordEnd - XwordStart - 2) + " ");

                                    YwordStart = line.IndexOf(CY) + CY.Length + 2;
                                    YwordEnd = line.IndexOf(R, YwordStart);

                                    tspWriter.WriteLine(line.Substring(YwordStart, YwordEnd - YwordStart - 2));
                                    //Console.WriteLine($"Xcoord: {svg.xCoord}, Ycoord: {svg.yCoord}");

                                    count++;
                                }

                            }
                            tspWriter.WriteLine(tspFile.EndofFile);
                            Console.WriteLine($"The TSP Problem file {tspFile.FullFileName} has been created");
                            return Constants.SUCCESS;
                        }

                    }
                }
                catch (Exception e)
                {

                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                    return Constants.FAILURE;
                }
            }
            else
            {
                Console.WriteLine($"The file {svgFile.FullFileName} does not have a dimension value");
                return Constants.FAILURE;
            }
        }

        //returns the number of lines in the svgFile which contains the word circle
        private int GetSvgFileCircleLineCount(SvgFile svgFile)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader svgReader = new StreamReader($"{filepath}{svgFile.FullFileName}"))
                {
                    string line;
                    var lineCount = 0;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line =svgReader.ReadLine()) != null)
                    {
                        if (line.Contains("circle"))
                        {
                            lineCount++;
                        }
                    }
                    return lineCount;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file {filepath}{svgFile.FullFileName} could not be opened");
                Console.Write(e.Message);
                return 0;
            }
        }
    }
}
