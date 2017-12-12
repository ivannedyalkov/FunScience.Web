namespace FunScience.Web.Areas.Admin.Controllers
{
    using FunScience.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public abstract class AdminBaseController : Controller
    {
        [TempData]
        public string StatusMessage { get; set; }
    }
}
