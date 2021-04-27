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
            public static string CreatedBy = "CreatedBy";
            public static string CreatedDate = "CreatedDate";
            public static string ModifiedBy = "ModifiedBy";
            public static string ModifiedDate = "ModifiedDate";
            public static string RowVersion = "RowVersion";
        }

        #endregion Shadow Properties

        #region Error

        /// <summary>
        /// Contains constants for User.
        /// </summary>
        public static class Error
        {
            public const int ERROR_UNIQUECONSTRAINT = 2601;
            public const string ERROR_CONCURRENCY = "DbConcurrencyError";
        }

        #endregion Error
    }
}
