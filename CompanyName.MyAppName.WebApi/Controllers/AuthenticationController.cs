using CompanyName.MyAppName.Domain.Services;
using CompanyName.MyAppName.WebApi.Common;
using CompanyName.MyAppName.WebApi.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Dm = CompanyName.MyAppName.Model.Models;

namespace CompanyName.MyAppName.WebApi.Controllers
{
    /// <summary>
    /// Provides various members to handle user authentication.
    /// Authenticaion is handled using JW token.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Member Variables

        private readonly ProjectSettings projectSettings;
        private readonly IAuthenticationService authService;

        #endregion Member Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        public AuthenticationController(IOptionsSnapshot<ProjectSettings> projectSettings,
                                        IAuthenticationService authService)
        {
            this.projectSettings = projectSettings.Value;
            this.authService = authService;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <returns>User details if user is authenticated else unathorized response.</returns>
        [HttpPost]
        public IActionResult AuthenticateUser([FromBody] Dm.User user)
        {
            var response = Unauthorized();

            if (user != null)
            {
                var userInfo = authService.ValidateUser(user.Name, user.Password);

                if (userInfo != null)
                {
                    var claims = CreatedClaims(user);
                    var authToken = SecurityHelper.GenerateJSONWebToken(projectSettings, claims);
                    return Ok(new { authToken });
                }
            }

            return response;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Createds the claims.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Claims</returns>
        private Claim[] CreatedClaims(Dm.User user)
        {
            return new[] {
                           new Claim("Username", user.Name),
                           new Claim("Email", "gaurav@gmail.com"),
                           new Claim("Role", "Admin")
                         };
        }

        #endregion Private Methods
    }
}
