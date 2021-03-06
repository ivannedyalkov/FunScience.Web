﻿namespace FunScience.Web.Controllers
{
    using AutoMapper;
    using FunScience.Data.Models;
    using FunScience.Service;
    using FunScience.Service.Admin;
    using FunScience.Web.Infrastructure;
    using FunScience.Web.Infrastructure.Helpers;
    using FunScience.Web.Models.ManageViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly ISchoolService schoolService;
        private readonly IUserScheduleService scheduleService;
        private readonly IMapper mapper;

        public ManageController(
          UserManager<User> userManager,
          SignInManager<User> signInManager,
             IUserService userService,
             ISchoolService schoolService,
             IUserScheduleService scheduleService,
             IMapper mapper
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.schoolService = schoolService;
            this.scheduleService = scheduleService;
            this.mapper = mapper;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public IActionResult Index(string id)
        {
            if (this.userManager.GetUserId(User) != id && !this.User.IsInRole(GlobalConstants.AdministratorRole))
            {
                id = this.userManager.GetUserId(User);
            }

            var user = this.userService.Details(id);

            if (user == null)
            {
                return BadRequest();
            }

            var userView = mapper.Map<DetailsUserViewModel>(user);

            userView.ImageSource = ImageConvertor.ConvertToImage(userView.UserPhoto);

            userView.StatusMessage = StatusMessage;

            return View(userView);
        }

        [HttpPost]
        public IActionResult Edit(DetailsUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.Id != null)
                {
                    model.ImageSource = ImageConvertor.ConvertToImage(
                        this.userService
                        .UserImage(model.Id));

                    return View("Index", model);
                }

                return BadRequest();
            }

            byte[] image = new byte[GlobalConstants.MaximumImageSize];

            if (model.Image != null)
            {
                image = ImageConvertor.ConvertToBytes(model.Image);
            }
            else
            {
                image = this.userService.UserImage(model.Id);
            }


            this.userService.Edit(
                                    model.Id,
                                    model.FirstName,
                                    model.LastName,
                                    model.PhoneNumber,
                                    model.Profession,
                                    model.FacebookUrlAddress,
                                    model.Description,
                                    image);

            StatusMessage = MessageConstants.ProfileChanged;

            if (User.IsInRole(GlobalConstants.AdministratorRole) && this.userManager.GetUserId(User) != model.Id)
            {
                return Redirect("/admin/home/");
            }

            return RedirectToAction("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = MessageConstants.PasswordChanged;

            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult Schedule()
        {
            var completeSchedule = this.scheduleService.GetSchedule(this.userManager.GetUserId(this.User));

            return View(completeSchedule);
        }

        public IActionResult SchoolInfo(string name)
        {
            var school = this.schoolService.SchoolInfo(name);

            return View(school);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
