namespace FunScience.Service.Admin.Models.Schedule
{
    using System;
    using System.Collections.Generic;

    public class ScheduleServiceModel
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public string PlayName { get; set; }

        public string SchoolName { get; set; }
        
        public IEnumerable<string> Participants { get; set; }
    }
}
