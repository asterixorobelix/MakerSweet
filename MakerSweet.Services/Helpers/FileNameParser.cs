using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public class FileNameParser
    {
        public string RemoveDotFileExtensionInFileName (string name)
        {
            if (name.Contains("."))
            {
                name = name.Split(".")[0];
            }
            return name;
        }
    }
}
