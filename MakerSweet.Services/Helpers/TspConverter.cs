using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MakerSweet.Services.Helpers
{
    public class TspConverter:ITspConverter
    {
        private const string CX = "cx";
        private const string CY = "cy";
        private const string R = "r";
        private readonly string filepath = Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH;

        public string ConvertCircleSVGtoTSP(string svgFileName)
        {
            var filenameParser = new FileNameParser();
            svgFileName = filenameParser.RemoveDotFileExtensionInFileName(svgFileName);

            var svgFile = new SvgFile(svgFileName);
            var tspFile = new TspFile(svgFile.FileName)
            {
                Dimension = GetSvgFileCircleLineCount(svgFile)//TSP file must contain information regarding how many circles that there are in the svgfile
            };

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
                            return $"The TSP Problem file {filepath}{tspFile.FullFileName} has been created";
                        }

                    }
                }
                catch (Exception e)
                {

                    // Let the user know what went wrong.
                    return $"The file {filepath}{svgFile.FullFileName} could not be read. {e.Message}";
                }
            }
            else
            {
                return $"The file {filepath}{svgFile.FullFileName} does not have a dimension value";
            }
        }

        public string ReorderSVGAccordingtoTSPsol(SvgFile oldSvgFile, TspSolFile tspSolFile, TspFile tspFile)
        {
            try
            {
                using(StreamReader oldSvgReader = new StreamReader($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{oldSvgFile.FullFileName}"))
                {
                    var reorderedSvgFile = new SvgFile($"Reordered{oldSvgFile.FullFileName}");
                    
                    using(StreamWriter reorderedSvgWriter = new StreamWriter($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{reorderedSvgFile.FullFileName}"))
                    {
                        List<int> tspSolOrder = GetTspSolLineOrder(tspSolFile, tspFile);
                        string line;
                        while ((line=oldSvgReader.ReadLine()) != null)
                        {
                            if (!line.Contains("circle"))
                            {
                                reorderedSvgWriter.WriteLine(line);
                            }
                                                       
                        }
                        return Constants.SUCCESS;
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

        /*Example beginning of a tspSolFile
         * ***  ***
         
         
         
         *** You chose the Concorde(CPLEX) solver ***
         
         
         
         *** Cities are numbered 0..n-1 and each line shows a leg from one city to the next 
          followed by the distance rounded to integers***
         
         1000 1000
         0 586 22  //Begins with city 0, travel to city 586, which is a distance of 22 units
         586 15 18
         15 477 22
         */
        private static List<int> GetTspSolLineOrder(TspSolFile tspSolFile, TspFile tspFile)
        {
            var tspSolOrder = new List<int>();
            string line;
            int firstSvgLineNumber;

            try
            {
                using(StreamReader tspSolReader = new StreamReader($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{tspSolFile.FullFileName}"))
                {
                    while ((line = tspSolReader.ReadLine()) != null)
                    {
                        int.TryParse((line.Split(null))[0],out firstSvgLineNumber);//split at whitespace, take first part and attempt to parse to int
                        if (firstSvgLineNumber != tspFile.Dimension)
                        {
                            tspSolOrder.Add(firstSvgLineNumber);
                        }
                    }
                    return tspSolOrder;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return tspSolOrder;
            }
        }
    }
}
