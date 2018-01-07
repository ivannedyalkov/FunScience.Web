namespace FunScience.Service.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FunScience.Data;
    using FunScience.Service.Admin.Models.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly FunScienceDbContext db;

        public UserService(FunScienceDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UsersListingModel> AllUsers()
        {
            var allUsers = this.db
                .Users
                .ProjectTo<UsersListingModel>()
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToList();

            return allUsers;
        }

        public void Delete(string id)
        {
            var user = this.db.Users.Find(id);

            if (user == null)
            {
                throw new ArgumentNullException("No such user in database.");
            }

            this.db.Users.Remove(user);

            this.db.SaveChanges();
        }

        public DeleteUserModel DeleteInfo(string id)
        {
            var user = this.db
                .Users
                .ProjectTo<DeleteUserModel>()
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException("No such user in database.");
            }

            return user;
        }

        public DetailsUserModel Details(string id)
        {
            var user = this.db
                .Users
                .ProjectTo<DetailsUserModel>()
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException("No such user in database.");
            }

            return user;
        }

        public void Edit(string id, string firstName, string lastName, string phoneNumber, string profession, string facebookUrlAddress, string description, byte[] image)
        {
            var user = this.db
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException("No such user in database.");
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNumber;
            user.Profession = profession;
            user.FacebookUrlAddress = facebookUrlAddress;
            user.Description = description;
            user.UserPhoto = image;

            this.db.SaveChanges();
        }

        public byte[] UserImage(string id)
        {
            var user = this.db
                .Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentNullException("No such user in database.");
            }

            return user.UserPhoto;
        }

        public bool UserExist(string id)
        {
            return this.db
                .Users
                .Any(u => u.Id == id);
        }
    }
}
