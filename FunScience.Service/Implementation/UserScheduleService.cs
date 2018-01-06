namespace FunScience.Service.Implementation
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using FunScience.Data;
    using FunScience.Service.Models;
    using FunScience.Data.Models;
    using System;

    public class UserScheduleService : IUserScheduleService
    {
        private readonly FunScienceDbContext db;

        public UserScheduleService(FunScienceDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserScheduleServiceModel> GetSchedule(string id)
        {
            return this.db
                .Performances
                .Where(p => (p.Time > DateTime.UtcNow) &&
                            (p.Users
                                    .Any(u => u.UserId == id)))
                .ProjectTo<UserScheduleServiceModel>()
                .ToList();
        }
    }
}
