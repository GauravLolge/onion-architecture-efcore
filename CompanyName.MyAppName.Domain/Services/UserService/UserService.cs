using CompanyName.MyAppName.Core.Entities;
using CompanyName.MyAppName.DataAccess;
using CompanyName.MyAppName.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Dm = CompanyName.MyAppName.Model.Models;

namespace CompanyName.MyAppName.Domain.Services
{
    /// <summary>
    /// Provides various members to handle operations for User entity.
    /// </summary>
    /// <seealso cref="CompanyName.MyAppName.Domain.Services.UserService.IUserService" />
    public class UserService : IUserService
    {
        #region Member Variables

        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitofWork;

        #endregion Member Variables

        #region public Metthods

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService(IRepository<User> userRepository,
                           IUnitOfWork unitofWork)
        {
            this.userRepository = userRepository;
            this.unitofWork = unitofWork;
        }


        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void AddUser(Dm.User user)
        {
            if (user != null)
            {
                User userEntity = new User() { Name = user.Name, Password = user.Password, IsActive = user.IsActive };

                userEntity.UserSetting = new UserSetting() { Setting = "" };

                userRepository.Add(userEntity);

                unitofWork.Save();
            }
        }

        /// <summary>
        /// Deletes the user by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteUserById(int Id)
        {
            if (Id != 0)
            {
                var user = userRepository.GetById(Id);

                if (user != null)
                {
                    userRepository.Remove(user);

                    unitofWork.Save();
                }
            }
        }


        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return userRepository.GetQueryable().ToList();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>User</returns>
        public User GetUserById(int Id)
        {
            User user = null;

            if (Id != 0)
            {
                user = userRepository.GetById(Id);
            }

            return user;
        }

        public void UpdateUserById(int Id)
        {
            if (Id != 0)
            {
                var user = userRepository.GetById(Id);

                user.Name = "UpdatedUserName";

                if (user != null)
                {
                    userRepository.Update(user);

                    unitofWork.Save();
                }
            }
        }

        #endregion public Methods
    }
}
