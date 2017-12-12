namespace FunScience.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.Infrastructure.DataConstants;

    public class Play
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(PlayNameMaxLenght)]
        public string Name { get; set; }

        public List<Performance> Performances { get; set; } = new List<Performance>();
    }
}
