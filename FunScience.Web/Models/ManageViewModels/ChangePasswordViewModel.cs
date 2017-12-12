namespace FunScience.Web.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърждаване на паролата")]
        [Compare("NewPassword", ErrorMessage = "Двете пароли не са еднакви.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
