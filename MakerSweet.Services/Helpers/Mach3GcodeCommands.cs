using System;

/*
 * https://machmotion.com/cnc-info/g-code.html
 * http://www.helmancnc.com/mach3-m-codes/
 * http://www.helmancnc.com/mach3-mill-g-code-list/
 * */

namespace MakerSweet.Services.Helpers
{
    public static class Mach3GcodeCommands
    {
        public static string GetFileFooter(double safeZHeight)
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

        public static string GetFileHeader(DateTime dateTime)
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
            M03 : Spindle on, clockwise rotation
            */
            return $"(This file was created on {dateTime}){Environment.NewLine}G17{Environment.NewLine}G21{Environment.NewLine}G90{Environment.NewLine}G80{Environment.NewLine}G64{Environment.NewLine}G00{Environment.NewLine}{Environment.NewLine}M03";
        }
        public static string FeedRate(double feed)
        {
            return $"F{feed}{Environment.NewLine}";
        }
        public static string RapidMove(double z)
        {
            //G00 = Rapid positioning
            return $"G0 Z{z}{Environment.NewLine}";
        }
        public static string RapidMove(double x, double y)
        {
            //G00 = Rapid positioning
            return $"G0 X{x} Y{y}{Environment.NewLine}";
        }

        public static string RapidMove(double x, double y, double z)
        {
            //G00 = Rapid positioning
            return $"G0 X{x} Y{y} Z{z}{Environment.NewLine}";
        }

        public static string ClockWiseArc(double i)
        {
            return $"G2 I{i}{Environment.NewLine}";
        }

        public static string RapidMoveToXYLocation(double z, double x, double y)
        {
            var up = Mach3GcodeCommands.RapidMove(z);
            var across = Mach3GcodeCommands.RapidMove(x, y);
            var down = Mach3GcodeCommands.RapidMove(-z);

            return up + across + down;
        }
    }
}
