using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Models
{
    public class SvgFile: File
    {
       public SvgFile(string name):base(name)
        {
            FileExtension = ".svg";
            FullName = FileName + FileExtension;
        }
        public int Dimension { get; set; }
    }
}
