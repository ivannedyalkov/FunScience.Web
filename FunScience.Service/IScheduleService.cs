namespace FunScience.Service
{
    using FunScience.Service.Admin.Models.Performance;
    using FunScience.Service.Admin.Models.Schedule;
    using System;
    using System.Collections.Generic;

    public interface IScheduleService
    {
        PerformanceModel GetSchedule();

        void CreateSchedule(DateTime time, int playId, int schoolId, IEnumerable<string> users);

        IEnumerable<ScheduleServiceModel> Schedule();
    }
}
