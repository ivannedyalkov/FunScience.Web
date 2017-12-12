using System;
using System.Collections.Generic;

namespace FunScience.Data.Models
{
    public class Performance
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public int PlayId { get; set; }

        public Play Play { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public List<UserPerformance> Users { get; set; } = new List<UserPerformance>();
    }
}
