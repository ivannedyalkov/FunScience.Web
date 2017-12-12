namespace FunScience.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.Infrastructure.DataConstants; 

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(UserNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(UserNameMaxLenght)]
        public string LastName { get; set; }
        
        public string Description { get; set; }
        
        [MaxLength(UserProfessionMaxLenght)]
        public string Profession { get; set; }

        [MaxLength(UserFacebookUrlMaxLenght)]
        public string FacebookUrlAddress { get; set; }

        public byte[] UserPhoto { get; set; }

        public List<UserPerformance> Performances { get; set; } = new List<UserPerformance>();
    }
}
