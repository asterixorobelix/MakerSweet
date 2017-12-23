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
            return $"(This file was created on {dateTime}){Environment.NewLine}G17{Environment.NewLine}G21{Environment.NewLine}G90{Environment.NewLine}G80{Environment.NewLine}G64{Environment.NewLine}G00{Environment.NewLine}M03{Environment.NewLine}";
        }
        public static string FeedRate(double feed)
        {
            return $"F{feed} ";
        }

        public static string RapidPositioning()
        {
            //G00 = Rapid positioning
            return $"G00 ";
        }
        public static string MoveZ(double z)
        {
            return $"Z{z} ";
        }

        public static string MoveX (double x)
        {
            return $"X{x} ";
        }

        public static string MoveY(double y)
        {
            return $"Y{y} ";
        }
        public static string MoveXY(double x, double y)
        {
            return $"X{x} Y{y} ";
        }

        public static string MoveXYZ(double x, double y, double z)
        {
            return $"X{x} Y{y} Z{z} ";
        }

        public static string ArcCenterXaxis(double i)
        {
            return $"I{i} ";
        }
        public static string ArcCenterYaxis(double j)
        {
            return $"J{j} ";
        }

        //When a tool moves along a line to the specified position at the feed rate specified.
        public static string LinearInterpolation()
        {
            return $"G01 ";
        }
        public static string CircularClockwiseInterpolation()
        {
            return $"G02 ";
        }

        public static string RapidMoveToXYLocation(double x, double y)
        {
            //Eg G00 X0.422 Y25
            var rapid = Mach3GcodeCommands.RapidPositioning();
            var across = Mach3GcodeCommands.MoveXY(x, y);
            return rapid+across +Environment.NewLine;
        }

        public static string ZPlunge(double z, double feedrate)
        {
            //Eg: G01 F30 Z-1
            return LinearInterpolation() + FeedRate(feedrate) + MoveZ(z) +Environment.NewLine;
        }

        public static string CutCircleXY(double f,double x, double y, double i, double j)
        {
            //eg: G02 F300 X-0.211 Y24.634537 I-0.422 J0
            return CircularClockwiseInterpolation() + FeedRate(f) + MoveX(x) + MoveY(y) + ArcCenterXaxis(i) + ArcCenterYaxis(j) + Environment.NewLine;
        }

        public static string LinearInterpolationXaxis(double x)
        {
            //eg: G01 X0.25
            return LinearInterpolation() + MoveX(x) + Environment.NewLine;
        }
    }
}
