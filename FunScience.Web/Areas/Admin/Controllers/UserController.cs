namespace FunScience.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using FunScience.Data.Models;
    using FunScience.Service.Admin;
    using FunScience.Service.Admin.Models.User;
    using FunScience.Web.Areas.Admin.Models;
    using FunScience.Web.Infrastructure;
    using FunScience.Web.Infrastructure.Helpers;
    using FunScience.Web.Models.ManageViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserController(
            IUserService userService,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        
        public async Task<IActionResult> Register()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            return View(new RegisterViewModel { });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                model.StatusMessage = $"{MessageConstants.UserWithSameEmailExist} {model.Email}.";

            }

            return View(nameof(Register), model);
        }

        public IActionResult Details(string id)
        {
            var user = this.userService.Details(id);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{id}'.");
            }

            var userView = mapper.Map<DetailsUserViewModel>(user);

            userView.ImageSource = ImageConvertor.ConvertToImage(userView.UserPhoto);

            userView.StatusMessage = StatusMessage;

            return View(userView);
        }

        public IActionResult Delete(string id)
        {
            DeleteUserModel model = this.userService.DeleteInfo(id);

            if (model == null)
            {
                return BadRequest("No details for this user.");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Destroy(DeleteUserModel model)
        {
            if (!this.userService.UserExist(model.Id))
            {
                throw new ApplicationException($"Unable to load user with ID '{model.Id}'.");
            }

            this.userService.Delete(model.Id);

            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
