using AutoMapper;
using CompanyName.MyAppName.DataAccess.Repositories;
using System.Linq;
using Dm = CompanyName.MyAppName.Model.Models;
using Et = CompanyName.MyAppName.Core.Entities;

namespace CompanyName.MyAppName.Domain.Services
{
    /// <summary>
    /// Provides various members for user authentication.
    /// </summary>
    /// <seealso cref="CompanyName.MyAppName.Domain.Services.AuthenticationService.IAuthenticationService" />
    public class AuthenticationService : IAuthenticationService
    {
        #region Member Variables

        private readonly IRepository<Et.User> userRepository;
        private readonly IMapper mapper;

        #endregion Member Variables

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="mapper">The mapper.</param>
        public AuthenticationService(IRepository<Et.User> userRepository,
                                     IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        #region Constructors

        #endregion Constructors

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>User</returns>
        public Dm.User ValidateUser(string username, string password)
        {
            Dm.User user = null;

            if (!string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password))
            {
                var userInfo = userRepository.GetQueryable(false)
                                     .Where(k => k.Name.ToLower() == username.ToLower() &&
                                                 k.Password == password)
                                     .Select(k => k)
                                     .FirstOrDefault();

                if (userInfo != null)
                {
                    user = mapper.Map<Dm.User>(userInfo);
                }
            }

            return user;
        }
    }
}
