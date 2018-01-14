
namespace FunScience.Web.Controllers
{
    using FunScience.Web.Models;
    using FunScience.Web.Models.AccountViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new LoginViewModel { });
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
