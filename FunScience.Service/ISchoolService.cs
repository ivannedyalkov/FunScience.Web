namespace FunScience.Service
{
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Models.School;
    using System.Collections.Generic;

    public interface ISchoolService
    {
        bool AddSchool(string name, string director, decimal lat, decimal lng);

        bool Edit(int id, string name, string director, decimal lat, decimal lng);

        SchoolListingModel DeleteInfo(int id);

        void Delete(int id);

        IEnumerable<SchoolListingModel> ListOfSchools();

        School SchoolInfo(int id);
    }
}
