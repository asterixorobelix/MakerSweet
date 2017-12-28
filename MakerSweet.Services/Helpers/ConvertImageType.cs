using ImageSharp;
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
                using (FileStream stream = new FileStream(path: $"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.jpg", mode: FileMode.Open))
                {
                    using (FileStream output = new FileStream(path: $"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png", mode: FileMode.Create))
                    {
                        using (Image image = new Image(stream))
                        {
                            image.Save(output);
                        }
                    }
                    return $"{filename}.png";
                }
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }            
        }
    }
}
