/*TSP lib format:
    NAME : a280
    COMMENT : drilling problem(Ludwig)
    TYPE : TSP
    DIMENSION: 280
    EDGE_WEIGHT_TYPE : EUC_2D
    NODE_COORD_SECTION
      1 288 149
      2 288 129
      3 270 133
      4 256 141
      5 256 157
      6 246 157
      ...
      ..
      EOF
  */

using System;

namespace MakerSweet.Services.Models
{
    public class TspFile:File
    {
        public TspFile(string name):base(name)
        {
            FileExtension = ".tsp";
            FullFileName = FileName + FileExtension;
            FileHeader = GetFileHeader(this);
        }
        public readonly string EndofFile = "EOF";

        public string FileHeader { get; private set; }
        public string SvgFileName { get; set; }
        public int Dimension { get; set; }

        public static string GetFileHeader(TspFile tspFile)
        {
            return $"NAME: {tspFile.FullFileName} {Environment.NewLine}COMMENT: {tspFile.DateCreated} created from:{tspFile.SvgFileName} {Environment.NewLine}TYPE: TSP {Environment.NewLine}DIMENSION: {tspFile.Dimension} {Environment.NewLine}EDGE_WEIGHT_TYPE : EUC_2D {Environment.NewLine}NODE_COORD_SECTION";
        }
    }
}
