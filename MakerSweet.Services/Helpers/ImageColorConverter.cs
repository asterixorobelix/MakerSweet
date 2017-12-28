using ImageSharp;
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
                using (FileStream stream = new FileStream(path: $"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png", mode: FileMode.Open))
                {
                    using (FileStream output = new FileStream(path: $"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}blackWhite.png", mode: FileMode.Create))
                    {
                        using (Image image = new Image(stream))
                        {
                            image.BlackWhite();
                            image.Save(output);
                        }
                    }
                    return $"{filename}BlackWhite.png";
                }                
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }
        }
    }
}
