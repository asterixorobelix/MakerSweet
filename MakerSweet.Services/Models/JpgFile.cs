using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Models
{
    public class JpgFile:File
    {
        public JpgFile(string name) : base(name)
        {
            FileExtension = ".jpg";
            FullFileName = FileName + FileExtension;
        }
    }
}
