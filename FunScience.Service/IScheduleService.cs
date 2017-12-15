using FunScience.Service.Admin.Models.Performance;

namespace FunScience.Service
{
    public interface IScheduleService
    {
        PerformanceModel GetSchedule();
    }
}
