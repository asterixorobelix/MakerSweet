using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public static class SVGParser
    {
        /*
        <?xml version = "1.0" ?>
        < !DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
        <svg width = "1024" height="1202" version="1.1" xmlns="http://www.w3.org/2000/svg">
        <circle cx = "306.982" cy="103.168" r="6.60929" fill="rgb(0,0,0)" />
        */
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
