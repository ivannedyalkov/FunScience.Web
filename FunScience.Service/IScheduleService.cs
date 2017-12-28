namespace FunScience.Service
{
    using FunScience.Service.Admin.Models.Performance;
    using System;
    using System.Collections.Generic;

    public interface IScheduleService
    {
        PerformanceModel GetSchedule();

        void CreateSchedule(DateTime time, int Play, int School, IEnumerable<string> Users);
    }
}
