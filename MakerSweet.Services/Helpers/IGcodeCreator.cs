using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public interface IGcodeCreator
    {
        string CreateCircularGCodeFile(string svgFileName, double safeZHeight, double cutFeedRate, double plungeFeedRate, double depthPerPass, double finalDepth, double bitsize);
    }
}
