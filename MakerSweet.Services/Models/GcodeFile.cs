using MakerSweet.Services.Helpers;
using System;

/*
 * http://www.warrensbrain.com/gcode-to-english-translator.html
 * https://machmotion.com/cnc-info/g-code.html
 */

namespace MakerSweet.Services.Models
{
    public class GcodeFile:File
    {
        public GcodeFile(string name, double safeZHeight) : base(name)
        {
            FileExtension = ".nc";
            FullFileName = FileName + FileExtension;
            FileFooter = Mach3GcodeCommands.GetFileFooter(safeZHeight);
            FileHeader = Mach3GcodeCommands.GetFileHeader(this.DateCreated, safeZHeight);
        }

        public double CutFeedRate { get; private set; }
        public double PlungeFeedRate { get; private set; }
        public double SafeZHeight { get; private set; }
        public double DepthPerPass { get; private set; }
        public double FinalDepth { get; private set; }
        public double BitSize { get; private set; }

        public string FileFooter { get; private set; }
        public string FileHeader { get; private set; }
    }
}
