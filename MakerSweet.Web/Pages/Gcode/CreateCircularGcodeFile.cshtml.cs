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

        public CreateCircularGcodeFileModel()
        {
            SafeZHeight = Constants.SAFETY_HEIGHT_DEFAULT;
            BitSize = Constants.BIT_SIZE_DEFAULT;
            DepthPerPass = Constants.DEPTH_PER_PASS_DEFAULT;
            CutFeedRate = Constants.CUT_FEEDRATE_DEFAULT;
            FinalDepth = Constants.TARGET_DEPTH_DEFAULT;
            PlungeFeedRate = Constants.PLUNGE_FEEDRATE_DEFAULT;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (DepthPerPass <= FinalDepth)
                {
                    IGcodeCreator _gcodeCreator = new GCodeCreator(svgFileName: InputFileName, safeZHeight: SafeZHeight, cutFeedRate: CutFeedRate, depthPerPass: DepthPerPass, finalDepth: FinalDepth, bitsize: BitSize, plungeFeedRate: PlungeFeedRate);
                    Message = _gcodeCreator.CreateCircularGCodeFile();
                    return Page();
                }
                Message = $" Your depth per pass of {DepthPerPass} cannot be greater than the target depth of {FinalDepth}";
                return Page();
            }
            Message = Constants.GENERIC_ERROR_MESSAGE;
            return Page();
        }
        [Required]
        [BindProperty]
        public double CutFeedRate { get; set; }
        [Required]
        [BindProperty]
        public double PlungeFeedRate { get; set; }
        [Required]
        [BindProperty]
        public double SafeZHeight { get; set; }
        [Required]
        [BindProperty]
        public double DepthPerPass { get; set; }
        [Required]
        [BindProperty]
        public double FinalDepth { get; set; }
        [Required]
        [BindProperty]
        public double BitSize { get; set; }
        [Required]
        [BindProperty]
        public string InputFileName { get; set; }

        public string Message { get; set; }
    }
}