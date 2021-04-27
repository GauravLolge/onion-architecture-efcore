namespace CompanyName.MyAppName.DataAccess
{
    /// <summary>
    /// Provides access to various members if unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the application database context.
        /// </summary>
        /// <value>
        /// The application database context.
        /// </value>
        AppDbContext AppDbContext { get; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

    }
}
