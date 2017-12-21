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
    }
}
