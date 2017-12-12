namespace FunScience.Web.Areas.Admin.Controllers
{
    using FunScience.Service.Admin;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminBaseController
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var listOfUsers = this.userService.AllUsers();

            return View(listOfUsers);
        }
    }
}
