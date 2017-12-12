using System;
using System.Collections.Generic;
using System.Text;

/*
 * http://www.warrensbrain.com/gcode-to-english-translator.html
 * https://machmotion.com/cnc-info/g-code.html
 */

namespace MakerSweet.Services.Models
{
    public class GcodeFile:File
    {
        public GcodeFile(string name) : base(name)
        {
            FileExtension = ".nc";
        }
    }
}
