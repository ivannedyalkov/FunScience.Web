namespace FunScience.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Performance
    {
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public int PlayId { get; set; }

        public Play Play { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public List<UserPerformance> Users { get; set; } = new List<UserPerformance>();
    }
}
