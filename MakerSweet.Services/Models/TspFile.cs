using System;
using System.Collections.Generic;
using System.Text;

namespace MakerSweet.Services.Models
{
    public class TspFile:File
    {
        public TspFile(string name):base(name)
        {
            FileExtension = ".tsp";
        }
        private readonly string EndofFile = "EOF";
        private string FileHeader = ($"NAME: {0} \nCOMMENT: {1} {2} \nTYPE: TSP\nDIMENSION: {3} \nEDGE_WEIGHT_TYPE : EUC_2D \nNODE_COORD_SECTION");
    }
}
