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
    public class OptimizeFromTSPsolModel : PageModel
    {
        private readonly ITspConverter _tspConverter;
        public OptimizeFromTSPsolModel(ITspConverter tspConverter)
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
                Message =_tspConverter.ReorderSVGAccordingtoTSPsol(TSPSolFile, FileToReorder);
                return Page();
            }
            return Page();
        }

        [BindProperty]
        [Required]
        public string TSPSolFile { get; set; }
        [BindProperty]
        [Required]
        public string FileToReorder { get; set; }
        public string Message { get; set; }
    }
}