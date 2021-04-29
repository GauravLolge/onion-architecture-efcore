using CompanyName.MyAppName.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.MyAppName.WebApi.Controllers
{
    /// <summary>
    /// Provides various members to handle common opertions of the appplication.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        #region Member Variables

        private readonly IUserService userService;

        #endregion Member Variables

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>Users</returns>
        public IActionResult GetAllUsers()
        {
            var users = userService.GetAllUsers();

            return Ok(users);
        }

        #endregion Public Methods

    }
}
