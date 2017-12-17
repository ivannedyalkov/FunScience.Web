namespace FunScience.Service.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FunScience.Data;
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Models.School;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SchoolService : ISchoolService
    {
        private readonly FunScienceDbContext db;

        public SchoolService(FunScienceDbContext db)
        {
            this.db = db;
        }

        public bool AddSchool(string name, string director, decimal lat, decimal lng)
        {
            if (this.db.Schools.Any(s => s.Name == name))
            {
                return false;
            }

            var school = new School
            {
                Name = name,
                Director = director,
                Lat = lat,
                Lng = lng
            };

            this.db.Schools.Add(school);

            this.db.SaveChanges();

            return true;
        }

        public bool Edit(int id, string name, string director, decimal lat, decimal lng)
        {
            var school = this.db
                .Schools
                .FirstOrDefault(s => s.Id == id);

            if (school == null)
            {
                throw new ArgumentNullException("No such school in database.");
            }

            if (school.Name != name && this.db.Schools.Any(s => s.Name == name && s.Id != id))
            {
                return false;
            }

            school.Name = name;
            school.Director = director;
            school.Lat = lat;
            school.Lng = lng;

            this.db.SaveChanges();

            return true;
        }

        public SchoolListingModel DeleteInfo(int id)
        {
            var school = this.db
                .Schools
                .FirstOrDefault(s => s.Id == id);

            if (school == null)
            {
                throw new ArgumentNullException("No such school in database.");
            }

            return this.db
                .Schools
                .ProjectTo<SchoolListingModel>()
                .FirstOrDefault(s => s.Id == id);
        }

        public void Delete(int id)
        {
            var school = this.db.Schools.Find(id);

            if (school == null)
            {
                throw new ArgumentNullException("No such school in database.");
            }

            this.db.Schools.Remove(school);

            this.db.SaveChanges();
        }

        public IEnumerable<SchoolListingModel> ListOfSchools()
        {
            return this.db
                .Schools
                .ProjectTo<SchoolListingModel>()
                .OrderBy(s => s.Name)
                .ToList();
        }

        public School SchoolInfo(int id)
        {
            var school = this.db
                .Schools
                .FirstOrDefault(s => s.Id == id);

            if (school == null)
            {
                throw new ArgumentNullException("No such school in database.");
            }

            return this.db.Schools.FirstOrDefault(s => s.Id == id);
        }
    }
}
