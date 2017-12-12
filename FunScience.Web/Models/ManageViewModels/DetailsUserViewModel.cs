namespace FunScience.Web.Models.ManageViewModels
{
    using FunScience.Web.Infrastructure.Validation;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    using static FunScience.Data.Infrastructure.DataConstants;

    public class DetailsUserViewModel
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(UserNameMaxLenght, ErrorMessage = "Не може да е по дълго от 100 символа.")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължителна.")]
        [MaxLength(UserNameMaxLenght, ErrorMessage = "Не може да е по дълга от 100 символа.")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Телефонът е задължителен.")]
        [RegularExpression("^(0[0-9]{9})$", ErrorMessage = "Телефонът трябва да е във формат 0 ХХХ ХХХ ХХХ.")]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Длъжността е задължителна.")]
        [MaxLength(UserProfessionMaxLenght, ErrorMessage = "Дължинатана на професията може да е до 50 символа.")]
        [Display(Name = "Длъжност")]
        public string Profession { get; set; }

        [RegularExpression(@"^(.*)(facebook\.com/)(.+)$", ErrorMessage ="Не валиден facebook.")]
        [MaxLength(UserFacebookUrlMaxLenght, ErrorMessage = "Дължинатана на линка може да е до 2000 символа.")]
        [Display(Name = "Facebook")]
        public string FacebookUrlAddress { get; set; }
        
        [ImageValidation(ErrorMessage = "Снимката трябва да е до 1 MB и с разширение .jpg, .png или .jpeg.")]
        [Display(Name = "Профилна снимка")]
        public IFormFile Image { get; set; }

        public byte[] UserPhoto { get; set; }

        public string ImageSource{ get; set; }

        public string StatusMessage { get; set; }
    }
}
