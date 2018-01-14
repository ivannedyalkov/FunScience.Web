namespace FunScience.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PerformanceViewModel
    {
        [Required]
        [Display(Name = "Дата и час")]
        public DateTime Time { get; set; }

        [Display(Name = "Пиеса")]
        public IEnumerable<SelectListItem> Plays { get; set; }

        [Required]
        public int Play { get; set; }

        [Display(Name = "Училище")]
        public IEnumerable<SelectListItem> Schools { get; set; }

        [Required]
        public int School { get; set; }

        [Display(Name = "Служители")]
        public IEnumerable<SelectListItem> Users { get; set; }

        [Required(ErrorMessage = "Моля въведете поне един участник в пиесата.")]
        public IEnumerable<string> SelectedUsers { get; set; }

        public string StatusMessage { get; set; }
    }
}
