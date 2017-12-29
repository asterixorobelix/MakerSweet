using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakerSweet.Web
{
    public static class Constants
    {
        public const string FILE_NAME_ERROR = "Please provide a file name";
        public const string FILE_NAME_PLACEHOLDER = "FileName";
        public const int STIPPLE_DEFAULT = 1000;
        public const double SIZING_FACTOR_DEFAULT = 0.8;
        public const string GENERIC_ERROR_MESSAGE = "Oops, something went wrong";
        public const string FEED_RATE_PLACEHOLDER = "Feedrate";
        public const double SAFETY_HEIGHT_DEFAULT = 5.5;
        public const double BIT_SIZE_DEFAULT = 4.3;
        public const double DEPTH_PER_PASS_DEFAULT = 1.0;
        public const double CUT_FEEDRATE_DEFAULT = 100;
        public const double PLUNGE_FEEDRATE_DEFAULT = 30;
        public const double TARGET_DEPTH_DEFAULT = 3.5;
        public const double STEP_OVER_DEFAULT = 0.4;
        public const int LINE_NUMBER_DEFAULT = 2000;
        public const string SUCCESS = "Success";
        public const string FAILURE = "Failure";
        public const int NUMBER_OF_PINS_DEFAULT = 200;
    }
}
