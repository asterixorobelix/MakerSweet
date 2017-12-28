using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakerSweet.Web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.DrillBits.Any())
            {
                return;   // DB has been seeded
            }

            var drillbits = new DrillBit[]
            {
            new DrillBit{BitDiameter = 3.2,ShankDiameter = 3.2, Notes = "561", Manufacturer ="Dremel"},
            new DrillBit{BitDiameter = 6.2,ShankDiameter = 3.2, Notes = "v groove", Manufacturer ="Dremel"},
            new DrillBit{BitDiameter = 4.3,ShankDiameter = 6.35, Notes = "Straight bit", Manufacturer ="Tork Craft"},
            new DrillBit{BitDiameter = 3.4,ShankDiameter = 6.35, Notes = "Straight bit", Manufacturer ="Tork Craft"},
            new DrillBit{BitDiameter = 9.525,ShankDiameter = 6.35, Notes = "90 degree v groove", Manufacturer ="Tork Craft"},
            new DrillBit{BitDiameter = 6.35,ShankDiameter = 6.35, Notes = "Ball nose end mill"}
            };
            foreach (DrillBit d in drillbits)
            {
                context.DrillBits.Add(d);
            }
            context.SaveChanges();            
        }
    }
}
