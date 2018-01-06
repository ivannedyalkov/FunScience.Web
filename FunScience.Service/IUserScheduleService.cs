namespace FunScience.Service
{
    using FunScience.Service.Models;
    using System.Collections.Generic;

    public interface IUserScheduleService
    {
        IEnumerable<UserScheduleServiceModel> GetSchedule(string id);
    }
}
