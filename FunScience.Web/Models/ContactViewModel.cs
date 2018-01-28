namespace FunScience.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Името трябва да е между 5 и 20 символа.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email адресът е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден Емаил адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително.")]
        public string Message { get; set; }
    }
}
