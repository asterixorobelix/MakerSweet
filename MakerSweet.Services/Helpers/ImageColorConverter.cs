using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public class ImageColorConverter: IImageColorConverter
    {
        public string ConvertPNGtoBlackWhite(string filename)
        {
            try
            {
                using (Image<Rgba32> image =  Image.Load<Rgba32>($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png"))
                {
                    image.Mutate(x=>x.BlackWhite());
                    image.Save($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}blackWhite.png");
                }
                    return $"{filename}BlackWhite.png";               
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }
        }
    }
}
