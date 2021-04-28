namespace CompanyName.MyAppName.Infra
{
    /// <summary>
    /// Defines constants being used across application.
    /// </summary>
    public static class Constants
    {
        #region Shadow Properties

        public static class ShadowProperty
        {
            public const string CREATED_BY = "CreatedBy";
            public const string CREATED_DATE = "CreatedDate";
            public const string MODIFIED_BY = "ModifiedBy";
            public const string MODIFIED_DATE = "ModifiedDate";
        }

        #endregion Shadow Properties

        #region Errors

        /// <summary>
        /// Contains constants for User.
        /// </summary>
        public static class Error
        {
            public const int ERROR_UNIQUECONSTRAINT = 2601;
            public const string ERROR_CONCURRENCY = "DbConcurrencyError";
        }

        #endregion Errors

        #region Config Keys

        public static class ConfigKeys
        {
            public const string JWT_KEY = "Jwt:SecretKey";
            public const string JWT_ISSUER = "Jwt:Issuer";
            public const string JWT_EXPIRY_TIME = "Jwt:ExpiryTime";
        }

        #endregion Config Keys

        #region Common

        public class Common
        {
            
        }

        #endregion Common
    }
}
