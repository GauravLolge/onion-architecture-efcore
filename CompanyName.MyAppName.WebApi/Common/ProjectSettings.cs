namespace CompanyName.MyAppName.WebApi.Common
{
    /// <summary>
    /// Provides various members to read keys from appp settings.
    /// </summary>
    public class ProjectSettings
    {
        /// <summary>
        /// Gets or sets the JWT key.
        /// </summary>
        /// <value>
        /// The JWT key.
        /// </value>
        public string JwtSecretKey { get; set; }

        /// <summary>
        /// Gets or sets the JWT issuer.
        /// </summary>
        /// <value>
        /// The JWT issuer.
        /// </value>
        public string JwtIssuer { get; set; }

        /// <summary>
        /// Gets or sets the JWT expiry time.
        /// </summary>
        /// <value>
        /// The JWT expiry time.
        /// </value>
        public string JwtExpiryTime { get; set; }
    }
}
