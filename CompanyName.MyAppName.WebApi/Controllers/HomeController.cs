using CompanyName.MyAppName.Core.Entities;
using CompanyName.MyAppName.DataAccess;
using CompanyName.MyAppName.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.MyAppName.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User> userRepo;
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="userRepo">The user repo.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public HomeController(IRepository<User> userRepo,
                              IUnitOfWork unitOfWork)
        {
            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
