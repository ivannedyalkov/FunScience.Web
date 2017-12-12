namespace FunScience.Data.Models
{
    public class UserPerformance
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int PerformanceId { get; set; }

        public Performance Performance { get; set; }
    }
}
