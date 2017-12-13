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
            FileFooter = GetFileFooter();
            FileHeader = GetFileHeader(this.DateCreated);
        }

        private static string GetFileFooter()
        {
            /*
             * G00
               Rapid positioning               
               Z3.5
               Absolute or incremental position of Z axis               
               M05
               Spindle stop               
               M30
               End of program, with return to program top
            */
            return "G00\nZ5.5\nM05\nM30";
        }

        private static string GetFileHeader(DateTime dateTime)
        {
            /*
            % : Pgm start/end delimiter
            G17 : XY plane selection
            G21 : Programming in millimeters (mm)
            G90 : Absolute programming
            G40 : Tool radius compensation off
            G49 : Tool length offset compensation cancel
            G80 : Cancel canned cycle
            G64 : Default cutting mode (cancel exact stop check mode)
            G00 : Rapid positioning
            Z5.5 : Move up 5.5 units from zero
            M03 : Spindle on, clockwise rotation
            */
            return $"(This file was created on {dateTime})\nG17\nG21\nG90\nG80\nG64\nG00\nZ5.5\nM03";
        }

        public string FileFooter { get; private set; }
        public string FileHeader { get; private set; }
    }
}
