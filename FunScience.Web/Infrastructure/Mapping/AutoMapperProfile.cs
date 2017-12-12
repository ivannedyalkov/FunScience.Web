namespace FunScience.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Admin.Models.School;
    using FunScience.Service.Admin.Models.User;
    using FunScience.Web.Areas.Admin.Models;
    using FunScience.Web.Models.ManageViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UsersListingModel>();

            this.CreateMap<User, DetailsUserModel>();

            this.CreateMap<User, DeleteUserModel>();

            this.CreateMap<DetailsUserModel, DetailsUserViewModel>();

            this.CreateMap<School, SchoolListingModel>();

            this.CreateMap<School, SchoolViewModel>();

            this.CreateMap<Play, PlayListingModel>();

            this.CreateMap<PlayListingModel, PlayViewModel>();
        }
        
        //в Service

        //using AutoMapper.QuerybleExtansions;

        // this.db.Users.ProjectTo<>UserViewModel>().ToList();

        //при променени полета

        // this.CreateMap<ApplicationUser, UserViewModel>()
        //.ForMember(u => u.MailAddress, cnf => cnf.MapFrom(u => u.Email));
    }
}
