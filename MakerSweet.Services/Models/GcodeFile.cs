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
            FileFooter = GetFileFooter(safeZHeight);
            FileHeader = GetFileHeader(this.DateCreated, safeZHeight);
        }        

        private static string GetFileFooter(double safeZHeight)
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
            return $"G00{Environment.NewLine}Z{safeZHeight}{Environment.NewLine}M05{Environment.NewLine}M30";
        }

        private static string GetFileHeader(DateTime dateTime, double safeZHeight)
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
            return $"(This file was created on {dateTime}){Environment.NewLine}G17{Environment.NewLine}G21{Environment.NewLine}G90{Environment.NewLine}G80{Environment.NewLine}G64{Environment.NewLine}G00{Environment.NewLine}Z{safeZHeight}{Environment.NewLine}M03";
        }

        public string FileFooter { get; private set; }
        public string FileHeader { get; private set; }
    }
}
