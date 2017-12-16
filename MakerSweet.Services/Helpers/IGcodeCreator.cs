using MakerSweet.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    interface IGcodeCreator
    {
        string CreateCircularGCodeFile(GcodeFile gcodeFile, TspFile tspFile);
    }
}
