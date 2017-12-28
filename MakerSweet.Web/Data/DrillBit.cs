using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MakerSweet.Web.Data
{
    public class DrillBit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DrillBitID { get; set; }
        [Required]
        public double BitDiameter { get; set; }
        public double ShankDiameter { get; set; }
        public string Manufacturer { get; set; }
        public string Notes { get; set; }
    }
}
