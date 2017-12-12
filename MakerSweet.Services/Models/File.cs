using MakerSweet.Services.Models;
using System;

namespace MakerSweet.Services
{
    public class File:IFile
    {
        public File(string name)
        {
            FileName = name;
            DateCreated = DateTime.Now;
            FileExtension = ".txt";
            FullName = FileName + FileExtension;
        }
        internal string FileExtension { get; set; }
        public string FileName { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
