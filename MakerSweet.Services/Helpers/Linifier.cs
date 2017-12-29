using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public class Linifier:ILinifier
    {
        public string Linfiy(string filename, int numberOfLines, int numberOfPins)
        {
            try
            {
                    //using (FileStream output = new FileStream(path: $"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}LineNo{numberOfLines}PinNo{numberOfPins}.png", mode: FileMode.Create))

                using (Image<Rgba32> image = Image.Load($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png"))
                {
                    image[200,200]=Rgba32.White;
                }
                return $"{filename}LineNo{numberOfLines}PinNo{numberOfPins}.png";
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }
        }
    }
}
