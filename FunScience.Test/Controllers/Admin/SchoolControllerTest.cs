namespace FunScience.Test.Controllers.Admin
{
    using FluentAssertions;
    using FunScience.Service;
    using FunScience.Service.Admin.Models.School;
    using FunScience.Web.Areas.Admin.Controllers;
    using FunScience.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class SchoolControllerTest
    {
        [Fact]
        public void SchoolControlerShouldBeOnlyForAdministrator()
        {
            //Arrange

            var controller =  typeof(SchoolController);
        
            //Act

            var attributes = controller
                                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                                .FirstOrDefault() as AuthorizeAttribute;

            var result = attributes.Roles.ToString() == GlobalConstants.AdministratorRole;

            //Assert

            result
                .Should()
                .Equals(true);
            
        }

        [Fact]
        public void SchoolsShouldreturnListOfSchool()
        {
            //Arrange

            var schoolService = new Mock<ISchoolService>();

            schoolService
                .Setup(s => s.ListOfSchools())
                .Returns(new List<SchoolListingModel>() { new SchoolListingModel { Id = 1, Name = "119" } });

            var controller = new SchoolController(schoolService.Object, null);

            //Act

            var result = controller.Schools();

            //Assert

            result
                .Should()
                .BeOfType<ViewResult>()
                .Subject
                .Model
                .Should()
                .Match(m => m.As<IEnumerable<SchoolListingModel>>()
                                            .First()
                                            .Name == "119");
        }
    }
}
