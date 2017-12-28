namespace FunScience.Service
{
    using FunScience.Service.Admin.Models.Performance;

    public interface IScheduleService
    {
        PerformanceModel GetSchedule();
    }
}
