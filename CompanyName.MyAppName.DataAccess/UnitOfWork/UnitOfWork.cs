using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CompanyName.MyAppName.DataAccess
{
    /// <summary>
    /// Provides various members to handle unit of work.
    /// </summary>
    /// <seealso cref="CompanyName.MyAppName.DataAccess.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The context.
        /// </summary>
        private AppDbContext context;

        /// <summary>
        /// The database context transaction.
        /// </summary>
        private readonly IDbContextTransaction dbContextTransaction = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the application database context.
        /// </summary>
        /// <value>
        /// The application database context.
        /// </value>
        public AppDbContext AppDbContext
        {
            get
            {
                if (context == null)
                {
                    context = new AppDbContext();
                }

                return context;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if(dbContextTransaction == null)
            {
                context.Database.BeginTransaction();
            }
        }

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            if (dbContextTransaction == null)
            {
                context.Database.RollbackTransaction();
            }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            if (dbContextTransaction == null)
            {
                context.Database.CommitTransaction();
            }
        }
    }
}
