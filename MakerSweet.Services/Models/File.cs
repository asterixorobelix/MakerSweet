using MakerSweet.Services.Models;
using System;
using MakerSweet.Services.Helpers;

namespace MakerSweet.Services
{
    public class File
    {
        public File(string name)
        {
            DateCreated = DateTime.Now;
            FileName = FileNameParser.RemoveDotFileExtensionInFileName(name);
            FileExtension = ".txt";
            FullFileName = FileName + FileExtension;
        }
        public string FileExtension { get; internal set; }
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public DateTime DateCreated { get; private set; }
    }
}
