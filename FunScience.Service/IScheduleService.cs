namespace FunScience.Service
{
    using FunScience.Service.Admin.Models.Performance;
    using FunScience.Service.Admin.Models.Schedule;
    using System;
    using System.Collections.Generic;

    public interface IScheduleService
    {
        PerformanceModel GetSchedule();

        bool CreateSchedule(DateTime time, int playId, int schoolId, IEnumerable<string> users);

        IEnumerable<ScheduleServiceModel> Schedule();

        ScheduleListingModel DeleteInfo(int id);

        void Delete(int id);

        PerformanceEditModel PerformanceInfo(int id);

        bool Edit(int id, DateTime time, int playId, int schoolId, IEnumerable<string> users);
    }
}
