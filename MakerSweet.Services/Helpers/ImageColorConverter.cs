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
                var threshold = 0.4f;// lower value leads to better results
                using (Image<Rgba32> image =  Image.Load<Rgba32>($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png"))
                {                    
                    image.Mutate(x=>x.BinaryThreshold(threshold));//formerly image.Mutate(x=>x.BlackWhite()); but this produced a greyscale image
                    image.Save($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}blackWhiteBinaryThreshold{threshold}.png");
                }
                    return $"{filename}blackWhiteBinaryThreshold{threshold}.png";               
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }
        }
    }
}
