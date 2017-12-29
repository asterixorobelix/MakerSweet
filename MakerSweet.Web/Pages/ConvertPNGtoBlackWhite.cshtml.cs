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
    public class ConvertPNGtoBlackWhiteModel : PageModel
    {
        private readonly IImageColorConverter _imageColorConverter;

        public ConvertPNGtoBlackWhiteModel(IImageColorConverter imageColorConverter)
        {
            _imageColorConverter = imageColorConverter;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                status =_imageColorConverter.ConvertPNGtoBlackWhite(FileName);
                if (status.Split(null)[0] != Constants.FAILURE)
                {
                    Message = $"The file {status} has successfully been created!";
                }
                else
                {
                    Message = $"The file {status} was not converted to black and white";
                }
                return Page();
            }
            return Page();
        }        

        [BindProperty]
        [Required(ErrorMessage = Constants.FILE_NAME_ERROR)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public string Message { get; set; }

        public string status { get; set; }
    }
}