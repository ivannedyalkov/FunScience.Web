namespace FunScience.Service.Admin.Models.Schedule
{
    using System.Collections.Generic;

    public class ScheduleServiceModel : ScheduleListingModel
    {
        public IEnumerable<string> Participants { get; set; }
    }
}
