using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public interface IGcodeCreator
    {
        string CreateCircularGCodeFile();

        double safeZHeight { set; }
        string svgFileName {  set; }
        double cutFeedRate {  set; }
        double plungeFeedRate { set; }
        double depthPerPass { set; }
        double finalDepth {  set; }
        double bitsize {  set; }
    }
}
