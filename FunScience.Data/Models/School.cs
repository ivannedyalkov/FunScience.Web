namespace FunScience.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.Infrastructure.DataConstants;

    public class School
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(SchoolNameMaxLenght)]
        public string Name { get; set; }

        public string Director { get; set; }

        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Lng { get; set; }

        public List<Performance> Performances { get; set; } = new List<Performance>();
    }
}
