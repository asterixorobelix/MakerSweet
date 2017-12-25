using MakerSweet.Services.Models;
using System;

namespace MakerSweet.Services
{
    public class TspSolFile:File
    {
        public TspSolFile(string name):base(name)
        {
            FileExtension = ".tspsol";
            FullFileName = FileName + FileExtension;
        }
    }
}
