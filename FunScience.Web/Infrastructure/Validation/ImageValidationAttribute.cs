namespace FunScience.Web.Infrastructure.Validation
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ImageValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;

            if (file == null)
            {
                return true;
            }

            if (file.Length > 2 * 1024 * 1024)
            {
                return false;
            }

            if (file.ContentType.Contains("image"))
            {
                return true;
            }
            
            string[] formats = new string[3] { ".jpg", ".png", ".jpeg" }; 

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}

