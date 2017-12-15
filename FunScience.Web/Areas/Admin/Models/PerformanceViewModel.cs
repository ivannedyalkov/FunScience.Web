namespace FunScience.Web.Areas.Admin.Models
{
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Admin.Models.School;
    using FunScience.Service.Admin.Models.User;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PerformanceViewModel
    {
        [Required]
        public DateTime Time { get; set; }

        public IEnumerable<SelectListItem> Plays { get; set; }

        public IEnumerable<SelectListItem> Schools { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
