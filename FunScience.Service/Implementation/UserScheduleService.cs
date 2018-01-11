namespace FunScience.Service.Implementation
{
    using AutoMapper.QueryableExtensions;
    using FunScience.Data;
    using FunScience.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
