using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public static class FileNameParser
    {
        public static string RemoveDotFileExtensionInFileName (string name)
        {
            if (name.Contains("."))
            {
                name = name.Split(".")[0];
            }
            return name;
        }
    }
}
