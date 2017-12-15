namespace FunScience.Service.Admin.Models.Performance
{
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Admin.Models.School;
    using FunScience.Service.Admin.Models.User;
    using System.Collections.Generic;

    public class PerformanceModel
    {
        public IEnumerable<PlayListingModel> Plays { get; set; }

        public IEnumerable<SchoolListingModel> Schools { get; set; }

        public IEnumerable<UsersListingModel> Users { get; set; }
    }
}
