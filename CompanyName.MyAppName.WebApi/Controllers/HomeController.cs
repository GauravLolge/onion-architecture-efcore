using CompanyName.MyAppName.Core.Entities;
using CompanyName.MyAppName.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.MyAppName.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User> userRepo;

        public HomeController(IRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
    }
}
