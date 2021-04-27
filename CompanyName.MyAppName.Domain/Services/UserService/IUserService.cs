using CompanyName.MyAppName.Core.Entities;
using System.Collections.Generic;
using Dm = CompanyName.MyAppName.Model.Models;

namespace CompanyName.MyAppName.Domain.Services.UserService
{
    /// <summary>
    /// Provides various members to handle operations for User entity.
    /// </summary>
    public interface IUserService 
    {
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void AddUser(Dm.User user);

        /// <summary>
        /// Updates the user by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void UpdateUserById(int Id);

        /// <summary>
        /// Deletes the user by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void DeleteUserById(int Id);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        User GetUserById(int Id);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();
    }
}
