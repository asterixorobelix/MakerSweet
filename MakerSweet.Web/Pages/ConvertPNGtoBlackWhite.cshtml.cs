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
                Message = $"The file {_imageColorConverter.ConvertPNGtoBlackWhite(FileName)} has successfully converted to black and white!";
                return Page();
            }
            return Page();
        }        

        [BindProperty]
        [Required(ErrorMessage = Constants.FILE_NAME_ERROR)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public string Message { get; set; }
    }
}