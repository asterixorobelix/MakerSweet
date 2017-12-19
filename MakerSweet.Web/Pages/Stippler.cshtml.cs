using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakerSweet.Web.Pages
{
    public class StipplerModel : PageModel
    {
        public StipplerModel()
        {
            StippleNumber = Constants.STIPPLE_DEFAULT;
            SizingFactor = Constants.SIZING_FACTOR_DEFAULT;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            return Page();
        }
        [BindProperty]
        [Required(ErrorMessage =Constants.FILE_NAME_ERROR)]
        public string FileName { get; set; }
        [BindProperty]
        [Required]
        [Range(100,100000)]
        public int StippleNumber { get; set; }
        [BindProperty]
        [Required]
        [Range(0.1,20)]
        public double SizingFactor { get; set; }
        public bool NoOverlap { get; set; }
    }
}