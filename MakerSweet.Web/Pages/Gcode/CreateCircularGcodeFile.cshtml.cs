using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MakerSweet.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakerSweet.Web.Pages.Gcode
{
    public class CreateCircularGcodeFileModel : PageModel
    {
        private readonly IGcodeCreator _gcodeCreator;

        public CreateCircularGcodeFileModel(IGcodeCreator gcodeCreator)
        {
            _gcodeCreator = gcodeCreator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
        [Required]
        [BindProperty]
        public int FeedRate { get; set; }
        [Required]
        [BindProperty]
        public int SafeZHeight { get; set; }

        public string Message { get; set; }
    }
}