using Dm = CompanyName.MyAppName.Model.Models;

namespace CompanyName.MyAppName.Domain.Services
{
    /// <summary>
    /// Provides various members for user authentication.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Dm.User ValidateUser(string username, string password);
    }
}
