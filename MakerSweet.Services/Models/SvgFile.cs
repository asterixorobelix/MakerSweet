using System;

namespace MakerSweet.Services.Models
{
    public class SvgFile: File
    {
       public SvgFile(string name):base(name)
        {
            FileExtension = ".svg";
            FullFileName = FileName + FileExtension;
            Footer = GetFileFooter();
        }
        public int Dimension { get; set; }
        public string Footer { get; private set; }

        public string FirstLineNonStandardLine { get; set; }

        private static string GetFileFooter()
        {
            return "</svg>";
        }
    }
}
