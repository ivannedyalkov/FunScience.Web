namespace FunScience.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    using static FunScience.Data.Infrastructure.DataConstants;

    public class SchoolViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        [MaxLength(SchoolNameMaxLenght, ErrorMessage = "Не може да е по дълго от 100 символа.")]
        [Display(Name = "Училище")]
        public string Name { get; set; }

        [Display(Name = "Директор")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Кординатите са задължителни")]
        [Display(Name = "Географска ширина")]
        [RegularExpression(@"^-?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Моля въведете коректи данни.")]
        public decimal Lat { get; set; }

        [Required(ErrorMessage = "Кординатите са задължителни")]
        [Display(Name = "Географска дължина")]
        [RegularExpression(@"^-?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Моля въведете коректи данни.")]
        public decimal Lng { get; set; }

        public string StatusMessage { get; set; }
    }
}
