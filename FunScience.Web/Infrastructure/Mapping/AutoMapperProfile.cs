namespace FunScience.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Models.Performance;
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Admin.Models.Schedule;
    using FunScience.Service.Admin.Models.School;
    using FunScience.Service.Admin.Models.User;
    using FunScience.Service.Models;
    using FunScience.Web.Areas.Admin.Models;
    using FunScience.Web.Models.ManageViewModels;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Linq;

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

            this.CreateMap<PlayListingModel, SelectListItem>()
                .ForMember(p => p.Value, cnf => cnf.MapFrom(p => p.Id))
                .ForMember(p => p.Text, cnf => cnf.MapFrom(p => p.Name));
            
            this.CreateMap<SchoolListingModel, SelectListItem>()
                .ForMember(p => p.Value, cnf => cnf.MapFrom(p => p.Id))
                .ForMember(p => p.Text, cnf => cnf.MapFrom(p => p.Name));
            
            this.CreateMap<UsersListingModel, SelectListItem>()
                .ForMember(p => p.Value, cnf => cnf.MapFrom(p => p.Id))
                .ForMember(p => p.Text, cnf => cnf.MapFrom(p => String.Concat(p.FirstName, " ", p.LastName)));

            this.CreateMap<PerformanceModel, PerformanceViewModel>()
                .ForMember(p => p.Plays, cnf => cnf.MapFrom(p => p.Plays))
                .ForMember(s => s.Schools, cnf => cnf.MapFrom(s => s.Schools))
                .ForMember(u => u.Users, cnf => cnf.MapFrom(u => u.Users));

            this.CreateMap<PerformanceEditModel, PerformanceEditViewModel>()
                .ForMember(p => p.Plays, cnf => cnf.MapFrom(p => p.Plays))
                .ForMember(s => s.Schools, cnf => cnf.MapFrom(s => s.Schools))
                .ForMember(u => u.Users, cnf => cnf.MapFrom(u => u.Users));

            this.CreateMap<Performance, UserScheduleServiceModel>()
                .ForMember(us => us.PlayName, cnf => cnf.MapFrom(p => p.Play.Name))
                .ForMember(us => us.SchoolName, cnf => cnf.MapFrom(p => p.School.Name));

            this.CreateMap<Performance, ScheduleListingModel>()
                .ForMember(us => us.PlayName, cnf => cnf.MapFrom(p => p.Play.Name))
                .ForMember(us => us.SchoolName, cnf => cnf.MapFrom(p => p.School.Name));
        }
    }
}
