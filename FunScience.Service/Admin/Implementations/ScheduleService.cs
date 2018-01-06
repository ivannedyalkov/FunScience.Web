﻿namespace FunScience.Service.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FunScience.Data;
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Models.Performance;
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Admin.Models.Schedule;
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

        public bool CreateSchedule(DateTime time, int playId, int schoolId, IEnumerable<string> users)
        {
            if (time < DateTime.UtcNow)
            {
                return false;
            }
            
            if (
                !users.Any(u => this.db
                                      .Performances
                                      .Any((p => p.Users
                                                   .Any(un => string.Concat(un.User.FirstName, " ", un.User.FirstName) == u 
                                                   && un.Performance.Time.AddHours(1) < time) 
                                                   )))
                )
            {
                return false;
            }


            var play = this.db.Plays.FirstOrDefault(p => p.Id == playId);

            var school = this.db.Schools.FirstOrDefault(s => s.Id == schoolId);

            var performance = new Performance
            {
                Time = time,
                Play = play,
                PlayId = playId,
                School = school,
                SchoolId = schoolId
            };

            foreach (var user in users)
            {
                performance.Users.Add(new UserPerformance { UserId = user });
            }

            this.db.Plays.FirstOrDefault(p => p.Id == playId).Performances.Add(performance);
            this.db.Schools.FirstOrDefault(s => s.Id == schoolId).Performances.Add(performance);

            this.db.Performances.Add(performance);

            this.db.SaveChanges();

            return true;
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

        public IEnumerable<ScheduleServiceModel> Schedule()
        {
            return this.db.Performances
                            .Select(p => new ScheduleServiceModel
                            {
                                Id = p.Id,
                                Time = p.Time,
                                PlayName = p.Play.Name,
                                SchoolName = p.School.Name,
                                Participants = p.Users
                                                .Select(u => string.Concat(u.User.FirstName, " ", u.User.LastName))
                                                .OrderBy(x => x)
                                                .ToList()
                            })
                            .OrderBy(p => p.Time)
                            .ToList();
        }
    }
}
