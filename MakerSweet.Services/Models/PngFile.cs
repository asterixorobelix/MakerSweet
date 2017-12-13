namespace MakerSweet.Services.Models
{
    public class PngFile:File
    {
        public PngFile(string name) : base(name)
        {
            FileExtension = ".png";
            FullFileName = FileName + FileExtension;
        }
    }
}
