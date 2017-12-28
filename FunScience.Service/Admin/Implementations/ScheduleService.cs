namespace FunScience.Service.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FunScience.Data;
    using FunScience.Service.Admin.Models.Performance;
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Admin.Models.School;
    using FunScience.Service.Admin.Models.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ScheduleService : IScheduleService
    {
        private readonly FunScienceDbContext db;

        public ScheduleService(FunScienceDbContext db)
        {
            this.db = db;
        }

        public void CreateSchedule(DateTime time, int Play, int School, IEnumerable<string> Users)
        {
            throw new NotImplementedException();
        }

        public PerformanceModel GetSchedule()
        {
            return new PerformanceModel
            {
                Plays = this.db
                        .Plays
                        .ProjectTo<PlayListingModel>()
                        .OrderBy(s => s.Name)
                        .ToList(),
                Schools = this.db
                        .Schools
                        .ProjectTo<SchoolListingModel>()
                        .OrderBy(s => s.Name)
                        .ToList(),
                Users = this.db
                        .Users
                        .ProjectTo<UsersListingModel>()
                        .OrderBy(u => u.FirstName)
                        .ThenBy(u => u.LastName)
                        .ToList()
            };
        }
    }
}
