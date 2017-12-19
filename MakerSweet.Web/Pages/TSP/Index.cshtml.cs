using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MakerSweet.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakerSweet.Web.Pages.TSP
{
    public class TSPCreatorModel : PageModel
    {
        private readonly ITspConverter _tspConverter;
        public TSPCreatorModel(ITspConverter tspConverter)
        {
            _tspConverter = tspConverter;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message= _tspConverter.ConvertCircleSVGtoTSP(InputFileName);
                return Page();
            }
            return Page();
        }

        [Required]
        [BindProperty]
        [Display(Name ="Input File Name")]
        public string InputFileName { get; set; }

        public string Message { get; set; }
    }
}