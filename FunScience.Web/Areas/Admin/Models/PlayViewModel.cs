namespace FunScience.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    using static FunScience.Data.Infrastructure.DataConstants;

    public class PlayViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [MinLength(3, ErrorMessage = "Името не може да е по кратко от 3 символа.")]
        [MaxLength(PlayNameMaxLenght, ErrorMessage = "Името не може да е по дълго от 40 символа.")]
        [Display(Name = "Име на пиесата")]
        public string Name { get; set; }

        public string StatusMessage { get; set; }
    }
}
