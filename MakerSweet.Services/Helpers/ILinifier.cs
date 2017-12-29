using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public interface ILinifier
    {
        string Linfiy(string filename, int numberOfLines, int numberOfPins);
    }
}
