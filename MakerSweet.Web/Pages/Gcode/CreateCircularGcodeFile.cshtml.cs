﻿using System.ComponentModel.DataAnnotations;
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
            SafeZHeight = Constants.SAFETY_HEIGHT_DEFAULT;
            BitSize = Constants.BIT_SIZE_DEFAULT;
            DepthPerPass = Constants.DEPTH_PER_PASS_DEFAULT;
            CutFeedRate = Constants.CUT_FEEDRATE_DEFAULT;
            FinalDepth = Constants.TARGET_DEPTH_DEFAULT;
            PlungeFeedRate = Constants.PLUNGE_FEEDRATE_DEFAULT;
            _gcodeCreator = gcodeCreator;
            StepOver = Constants.STEP_OVER_DEFAULT;

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
                    _gcodeCreator.safeZHeight = SafeZHeight;
                    _gcodeCreator.svgFileName = InputFileName;
                    _gcodeCreator.cutFeedRate = CutFeedRate;
                    _gcodeCreator.depthPerPass = DepthPerPass;
                    _gcodeCreator.finalDepth = FinalDepth;
                    _gcodeCreator.bitsize = BitSize;
                    _gcodeCreator.plungeFeedRate=PlungeFeedRate;
                    _gcodeCreator.stepOver = StepOver;

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
        public double StepOver { get; set; }
        [Required]
        [BindProperty]
        public double Coin1Size { get; set; }
        [Required]
        [BindProperty]
        public double Coin2Size { get; set; }
        [Required]
        [BindProperty]
        public double Coin3Size { get; set; }

        [BindProperty]
        public double Coin4Size { get; set; }
        [Required]
        [BindProperty]
        public string InputFileName { get; set; }

        public string Message { get; set; }
    }
}