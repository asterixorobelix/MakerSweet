using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public class ConvertImageType:IConvertImageType
    {
        public string JPGtoPNGConverter(string filename)
        {
            try
            {
                using (Image<Rgba32> image =Image.Load<Rgba32>($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.jpg"))
                {
                    image.Save($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png");
                }
                return $"{filename}.png";
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }            
        }
    }
}
