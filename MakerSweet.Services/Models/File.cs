using MakerSweet.Services.Models;
using System;

namespace MakerSweet.Services
{
    public class File
    {
        public File(string name)
        {
            FileName = name;
            DateCreated = DateTime.Now;
            FileExtension = ".txt";
            FullName = FileName + FileExtension;
        }
        public string FileExtension { get; internal set; }
        public string FileName { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreated { get; private set; }
    }
}
