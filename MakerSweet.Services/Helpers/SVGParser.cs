using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public static class SVGParser
    {
        public static List<double> ParseCircleSVGLine(string line)
        {
            var CxCyR = new List<double>();
            line = line.Replace("\"", string.Empty);
            string[] coords = line.Split(" ");
            
            if (coords.Length != 0)
            {
                double parsedResult;
                var cx = coords[1].Split("=");
                double.TryParse(cx[1], out parsedResult);
                CxCyR.Add(parsedResult);
                var cy = coords[2].Split("=");
                double.TryParse(cy[1], out parsedResult);
                CxCyR.Add(parsedResult);
                var cr = coords[3].Split("=");
                double.TryParse(cr[1], out parsedResult);
                CxCyR.Add(parsedResult);
            }
            return CxCyR;
        }
    }
}
