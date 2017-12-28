using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MakerSweet.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakerSweet.Web.Pages
{
    public class LinifierModel : PageModel
    {
        private readonly ILinifier _linifier;
        public LinifierModel(ILinifier linifier)
        {
            _linifier = linifier;
            NumberOfLines = Constants.LINE_NUMBER_DEFAULT;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _linifier.Linfiy(FileName, NumberOfLines);
                return Page();
            }
            return Page();
        }

        [BindProperty]
        [Required(ErrorMessage = Constants.FILE_NAME_ERROR)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [BindProperty]
        [Required]
        [Range(100, 100000)]
        [Display(Name = "Number of lines")]
        public int NumberOfLines { get; set; }

        public string Message { get; set; }
    }
}