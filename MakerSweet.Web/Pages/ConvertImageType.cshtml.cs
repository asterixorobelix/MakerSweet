using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MakerSweet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakerSweet.Web.Pages
{
    public class ConvertImageTypeModel : PageModel
    {
        private readonly IConvertImageType _convertImageType;

        public ConvertImageTypeModel(IConvertImageType convertImageType)
        {
            _convertImageType = convertImageType;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = $"The file {_convertImageType.JPGtoPNGConverter(FileName)} has been successfully created!";
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