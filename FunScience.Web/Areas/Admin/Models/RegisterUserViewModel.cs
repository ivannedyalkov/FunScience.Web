namespace FunScience.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    using static FunScience.Data.Infrastructure.DataConstants;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(UserNameMaxLenght, ErrorMessage = "Името не може да е по дълго от 100 символа.")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължителна.")]
        [MaxLength(UserNameMaxLenght, ErrorMessage = "Фамилията не може да е по дълга от 100 символа.")]
        [Display(Name = "Фамиля")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email адресът е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден Емаил адрес.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна.")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърждаване на паролата.")]
        [Compare("Password", ErrorMessage = "Двете пароли не са еднакви.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}