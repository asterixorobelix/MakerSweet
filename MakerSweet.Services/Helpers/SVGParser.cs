using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public static class SVGParser
    {
        public static List<int> ParseCircleSVGLine(string line)
        {
            var CxCyR = new List<int>();
            
            string[] coords = line.Split("=");
            
            if (coords.Length != 0)
            {
                int parsedResult;
                int.TryParse(coords[0], out parsedResult);
                CxCyR.Add(parsedResult);
                int.TryParse(coords[1], out parsedResult);
                CxCyR.Add(parsedResult);
                int.TryParse(coords[2], out parsedResult);
                CxCyR.Add(parsedResult);
            }
            return CxCyR;
        }
    }
}
