using System;
using System.Collections.Generic;
using System.Text;

/*https://github.com/SixLabors/ImageSharp/blob/master/features.md
 * According to ImageSharpDocumentation, there is support for:
 *  BlackWhite
 Grayscale BT709
 Grayscale BT601
 Hue
 Saturation
 Lomograph
 Polaroid
 Kodachrome
 Sepia
 Achromatomaly
 Achromatopsia
 Deuteranomaly
 Deuteranopia
 Protanomaly
 Protanopia
 Tritanomaly
 Tritanopia
 */

namespace MakerSweet.Services.Helpers
{
    public interface IImageColorConverter
    {
        string ConvertPNGtoBlackWhite(string filename);
    }
}
