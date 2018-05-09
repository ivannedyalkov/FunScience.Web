using FunScience.Service.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunScience.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly IUserService userService;

        public TeamController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("/team/news")]
        public IActionResult News()
        {
            return View();
        }

        [Route("/team/about")]
        public IActionResult About()
        {
            var listOfUsers = this.userService.GetUsers().ToList();

            return View(listOfUsers);
        }
    }
}
