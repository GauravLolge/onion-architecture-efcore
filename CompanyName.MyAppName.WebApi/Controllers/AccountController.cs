﻿using CompanyName.MyAppName.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
    public class AccountController : ControllerBase
    {
        #region Member Variables

        private readonly IConfiguration config;

        #endregion Member Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController(IConfiguration config)
        {
            this.config = config;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Token if user is valid.</returns>
        [HttpGet]
        public IActionResult SignIn()
        {
            var response = Unauthorized();

            if ("" != null && IsValidUser(null))
            {
                var authToken = GenerateJSONWebToken();
                return Ok(new { authToken });
            }

            return response;
        }

        #endregion Public Methods

        #region Private Methods

        /// TODO
        /// <summary>
        /// Determines whether [is valid user] [the specified user].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <c>true</c> if [is valid user] [the specified user]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidUser(Dm.User user)
        {
            var valid = true;



            return valid;
        }

        /// <summary>
        /// Generates the json web token.
        /// </summary>
        /// <returns>Jwt Token</returns>
        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config[Constants.ConfigKeys.JWT_KEY]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config[Constants.ConfigKeys.JWT_ISSUER],
                                  config[Constants.ConfigKeys.JWT_ISSUER],
                                  null,
                                  expires: DateTime.Now.AddMinutes(Convert.ToInt32(config[Constants.ConfigKeys.JWT_EXPIRY_TIME])),
                                  signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion Private Methods
    }
}
