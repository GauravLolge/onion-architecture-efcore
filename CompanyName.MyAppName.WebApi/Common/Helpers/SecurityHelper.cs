using CompanyName.MyAppName.Infra;
using Microsoft.Extensions.Configuration;
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
        /// <returns>Jwt Token</returns>
        public static string GenerateJSONWebToken(IConfiguration config)
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
    }
}
