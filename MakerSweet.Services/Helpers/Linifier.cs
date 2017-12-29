using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MakerSweet.Services.Helpers
{
    public class Linifier:ILinifier
    {
        private static int imageHeight { get; set; }
        private static int imageWidth { get; set; }
        private static int numberofPins { get; set; }
        private static List<int> startingCoords { get; set; }
        private static List<int> endingCoords { get; set; }
        private static int count { get; set; }
        private static int deltaHeight { get; set; }
        private static int deltaWidth { get; set; }

        public string Linfiy(string filename, int numberOfLines, int numberOfPins)
        {
            numberofPins = numberOfPins;
            try
            {
                using (Image<Rgba32> image = Image.Load($"{Constants.INPUTOUTPUT_FOLDER_RELATIVE_PATH}{filename}.png"))
                {
                    count = 0;
                    imageHeight = image.Height; //height of image in pixels
                    imageWidth = image.Width;
                    startingCoords = randomCoords();
                    endingCoords = randomCoords();                    

                    var xCoord = startingCoords[0];
                    var yCoord = startingCoords[1];

                    while (xCoord != endingCoords[0])
                    {
                        evaluateIfPixelBlack(image, xCoord, startingCoords[1]);
                        xCoord++;
                    }

                    while (yCoord != endingCoords[1])
                    {
                        evaluateIfPixelBlack(image, startingCoords[0], yCoord);
                        yCoord++;
                    }
                }
                return $"{filename}LineNo{numberOfLines}PinNo{numberOfPins}.png";
            }
            catch (Exception e)
            {
                return $"{Constants.FAILURE} - Unable to find file: {filename}. {e.Message}";
            }
        }

        //returns a list containing two integers, generated randomly between imageheight and imagewidth
        private static List<int> randomCoords()
        {            
            var random = new Random();
            var randomHeight = random.Next(0, imageHeight+1);//int month = rnd.Next(1, 13); // creates a number between 1 and 12
            var randomWidth = random.Next(0, imageWidth + 1);
            var coords = new List<int> {randomHeight,randomWidth };
            return coords;
        }

        private static void evaluateIfPixelBlack(Image<Rgba32> image,int xcoord,int ycoord)
        {
            var pixel = image[xcoord, ycoord];//eg: <1  1  1  1> <r g b a>

            if (pixel == Rgba32.Black)//ie black pixel
            {
                count++;
            }
        }

        private static void getDeltaHeightWidth()
        {
            deltaHeight =Math.Abs(startingCoords[0] - endingCoords[0]);
            deltaWidth =Math.Abs(startingCoords[1] - endingCoords[1]);
        }
    }
}
