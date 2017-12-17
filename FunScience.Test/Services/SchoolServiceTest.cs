namespace FunScience.Test.Services
{
    using Data;
    using FluentAssertions;
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Implementations;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using Xunit;

    public class SchoolServiceTest
    {
        private DbContextOptions<FunScienceDbContext> dbOptions;
        private FunScienceDbContext db;
        private SchoolService schoolService;

        public SchoolServiceTest()
        {
            this.dbOptions = new DbContextOptionsBuilder<FunScienceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            this.db = new FunScienceDbContext(dbOptions);

            this.schoolService = new SchoolService(db);
            
            CreateFakeSchools();

            Tests.Initialize();
        }

        private School FirstSchool => new School { Id = 1, Name = "110", Director = "Ivan", Lat = 1, Lng = 2 };
        private School SecondSchool => new School { Id = 2, Name = "111", Director = "Pesho", Lat = 3, Lng = 4 };
        private School ThirdSchool => new School { Id = 3, Name = "112", Director = "Gosho", Lat = 5, Lng = 6 };

        private void CreateFakeSchools()
        {
            db.Schools.AddRange(this.FirstSchool, this.SecondSchool, this.ThirdSchool);

            db.SaveChanges();
        }

        [Fact]
        public void ShouldReturnCorrectInfoAboutTheSchool()
        {
            //Arrange

            int firstSchoolId = 1; 

            //Act

            var result = schoolService.SchoolInfo(firstSchoolId);

            //Assert

            result.ShouldBeEquivalentTo(this.FirstSchool);
        }

        [Fact]
        public void ShouldReturnExceptionIfNoSchoolInDb()
        {
            //Arrange

            int schoolId = 5;

            //Act

            Action result = () => schoolService.SchoolInfo(schoolId);

            //Assert

            result.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ShouldReturnAllSchoolsFromDb()
        {
            //Arrange

            int schoolCount = 3;

            //Act

            var listOfSchools = schoolService.ListOfSchools();
            var numberOfSchools = listOfSchools.ToList().Count;

            //Assert

            numberOfSchools.ShouldBeEquivalentTo(schoolCount);
        }
    }
}
