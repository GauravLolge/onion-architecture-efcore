using CompanyName.MyAppName.Domain.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Dm = CompanyName.MyAppName.Model.Models;

namespace CompanyName.MyAppName.WebApi.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            Dm.User user = new Dm.User() { Name = "Tom" ,IsActive = true };

            userService.AddUser(user);

            var users = userService.GetAllUsers();


            foreach(var u in users)
            {
                var settting = u.UserSetting;
            }

            return View();
        }
    }
}
