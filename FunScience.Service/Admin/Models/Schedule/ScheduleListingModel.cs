namespace FunScience.Service.Admin.Models.Schedule
{
    using System;

    public class ScheduleListingModel
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public string PlayName { get; set; }

        public string SchoolName { get; set; }
    }
}
