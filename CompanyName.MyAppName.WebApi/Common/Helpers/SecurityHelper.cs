using CompanyName.MyAppName.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CompanyName.MyAppName.WebApi.Common.Helpers
{
    /// <summary>
    /// provides variuos members to manage security of the application.
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// Generates the json web token.
        /// </summary>
        /// <param name="projectSettings">The project settings.</param>
        /// <returns></returns>
        public static string GenerateJSONWebToken(ProjectSettings projectSettings)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(projectSettings.JwtSecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(projectSettings.JwtIssuer,
                                  projectSettings.JwtIssuer,
                                  null,
                                  expires: DateTime.Now.AddMinutes(Convert.ToInt32(projectSettings.JwtExpiryTime)),
                                  signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
