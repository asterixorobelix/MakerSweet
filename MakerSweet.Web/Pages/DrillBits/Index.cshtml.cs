using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakerSweet.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakerSweet.Web.Pages.DrillBits
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            DrillBits = _context.DrillBits.ToList();

        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public List<DrillBit> DrillBits { get; set; }
    }
}