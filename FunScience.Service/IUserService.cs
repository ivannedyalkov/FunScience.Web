namespace FunScience.Service.Admin
{
    using FunScience.Service.Admin.Models.User;
    using System.Collections.Generic;

    public interface IUserService 
    {
        IEnumerable<UsersListingModel> AllUsers();

        DetailsUserModel Details(string id);

        void Edit(string id, string firstName, string lastName, string phoneNumber, string profession, string facebookUrlAddress, string description, byte[] image);

        byte[] UserImage(string id);

        DeleteUserModel DeleteInfo(string id);

        void Delete(string id);

        bool UserExist(string id);
    }
}
