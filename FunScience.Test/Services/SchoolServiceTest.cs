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
            Tests.Initialize();

            this.db = Tests.GetDb();

            this.schoolService = new SchoolService(this.db);
            
            CreateFakeSchools();
        }

        private School FirstSchool => new School { Id = 11, Name = "110", Director = "Ivan", Lat = 1, Lng = 2 };
        private School SecondSchool => new School { Id = 12, Name = "111", Director = "Pesho", Lat = 3, Lng = 4 };
        private School ThirdSchool => new School { Id = 13, Name = "112", Director = "Gosho", Lat = 5, Lng = 6 };

        private void CreateFakeSchools()
        {
            this.db.Schools.AddRange(this.FirstSchool, this.SecondSchool, this.ThirdSchool);

            this.db.SaveChanges();
        }

        [Fact]
        public void ShouldReturnCorrectInfoAboutTheSchool()
        {
            //Arrange

            int firstSchoolId = 11; 

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

        [Fact]
        public void ShouldDeleteSchoolFromDb()
        {
            //Arrange

            int deleteSchoolById = 11;
            int schoolCount = 2;

            //Act

            this.schoolService.Delete(deleteSchoolById);
            var numberOfSchools = schoolService.ListOfSchools().ToList().Count;

            //Assert

            numberOfSchools.ShouldBeEquivalentTo(schoolCount);
        }

        [Fact]
        public void ShouldReturnExceptionIfTryToDeleteSchoolThatNonExist()
        {
            //Arrange

            int schoolId = 5;

            //Act

            Action result = () => this.schoolService.Delete(schoolId);

            //Assert

            result.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ShouldReturnCorrectInfoAboutTheDeleteInfoSchoolModel()
        {
            //Arrange

            int firstSchoolId = 12;

            //Act

            var result = schoolService.SchoolInfo(firstSchoolId);

            //Assert

            result.ShouldBeEquivalentTo(this.SecondSchool);
        }

        [Fact]
        public void ShouldReturnExceptionIfNoSchoolInDbDeleteInfo()
        {
            //Arrange

            int schoolId = 5;

            //Act

            Action result = () => schoolService.DeleteInfo(schoolId);

            //Assert

            result.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void EditSchoolInDb()
        {
            //Arrang

            var schoolId = 11;
            var name = "200";
            var director = "Tested";
            var lat = 99;
            var lng = 100;

            //Act

            var editSchoolService = this.schoolService.Edit(
                                                    schoolId,
                                                    name,
                                                    director,
                                                    lat,
                                                    lng
                                                    );

            var result = this.db
               .Schools
               .FirstOrDefault(s => s.Id == schoolId);
            
            //Assert

            editSchoolService.ShouldBeEquivalentTo(true);

            result.Name.ShouldAllBeEquivalentTo(name);
            result.Director.ShouldAllBeEquivalentTo(director);
            result.Lat.Equals(lat);
            result.Lng.Equals(lng);
        }

        [Fact]
        public void ShouldReturnFalseIfTryToEditSchoolNameWithExistingSchollNameInDb()
        {
            //Arrang

            var schoolId = 11;
            var name = "111";
            var director = "Tested";
            var lat = 99;
            var lng = 100;

            //Act

            var result = this.schoolService.Edit(
                                                    schoolId,
                                                    name,
                                                    director,
                                                    lat,
                                                    lng
                                                    );

            //Assert

            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void ShouldReturnExceptionIfTryEditSchoolWithNoExistingSchoolIdDb()
        {
            //Arrange

            var schoolId = 5;
            var name = "111";
            var director = "Tested";
            var lat = 99;
            var lng = 100;

            //Act

            Action result = () => this.schoolService.Edit(
                                                    schoolId,
                                                    name,
                                                    director,
                                                    lat,
                                                    lng
                                                    );

            //Assert

            result.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddSchoolInDb()
        {
            //Arrang
            
            var name = "55";
            var director = "Tested";
            var lat = 99;
            var lng = 100;

            //Act

            var addSchoolService = this.schoolService.AddSchool(
                                                    name,
                                                    director,
                                                    lat,
                                                    lng
                                                    );

            var result = this.db
               .Schools
               .FirstOrDefault(s => s.Name == name);

            //Assert

            addSchoolService.ShouldBeEquivalentTo(true);

            result.Name.ShouldAllBeEquivalentTo(name);
            result.Director.ShouldAllBeEquivalentTo(director);
            result.Lat.Equals(lat);
            result.Lng.Equals(lng);
        }

        [Fact]
        public void ShouldReturnFalseIfTryToAddSchoolWithNameThatAllreadyExistInDb()
        {
            //Arrang
            
            var name = "110";
            var director = "Tested";
            var lat = 99;
            var lng = 100;

            //Act

            var result = this.schoolService.AddSchool(
                                                    name,
                                                    director,
                                                    lat,
                                                    lng
                                                    );

            //Assert

            result.ShouldBeEquivalentTo(false);
        }
    }
}
