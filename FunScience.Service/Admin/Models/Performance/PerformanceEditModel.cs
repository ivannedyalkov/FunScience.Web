namespace FunScience.Service.Admin.Models.Performance
{
    using System;

    public class PerformanceEditModel : PerformanceModel
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }
    }
}
