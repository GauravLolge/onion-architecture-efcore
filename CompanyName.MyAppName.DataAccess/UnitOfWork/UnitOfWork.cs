using CompanyName.MyAppName.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Threading;

namespace CompanyName.MyAppName.DataAccess
{
    /// <summary>
    /// Provides various members to handle unit of work.
    /// </summary>
    /// <seealso cref="CompanyName.MyAppName.DataAccess.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        #region Member Variables

        /// <summary>
        /// The context.
        /// </summary>
        private AppDbContext context;

        /// <summary>
        /// The database context transaction.
        /// </summary>
        private readonly IDbContextTransaction dbContextTransaction = null;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed = false;

        #endregion Member Variables

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        #endregion Constructors

        #region public Methods

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
        /// Saves the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>1/0 based on success/fail</returns>
        public int Save()
        {
            int result = 0;

            try
            {
                SetShadowProperties();

                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }

            return result;
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if (dbContextTransaction == null)
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

        /// <summary>
        /// Enables the automatic detect changes.
        /// </summary>
        public void EnableAutoDetectChanges()
        {
            context.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        /// <summary>
        /// Disables the automatic detect changes.
        /// </summary>
        public void DisableAutoDetectChanges()
        {
            context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Sets the shadow properties.
        /// </summary>
        private void SetShadowProperties()
        {
            string user = string.Empty;

            var entities = context.ChangeTracker
                                  .Entries()
                                  .Where(x => x.State == EntityState.Added ||
                                              x.State == EntityState.Modified);

            //if (string.IsNullOrWhiteSpace(user))
            //{   
            //    user = Thread.CurrentPrincipal.Identity.Name;
            //}

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(Constants.ShadowProperty.CreatedDate).CurrentValue = DateTime.UtcNow;
                    entity.Property(Constants.ShadowProperty.ModifiedBy).CurrentValue = "Gaurav010001";
                }

                entity.Property(Constants.ShadowProperty.ModifiedDate).CurrentValue = DateTime.UtcNow;
                entity.Property(Constants.ShadowProperty.ModifiedBy).CurrentValue = "Gaurav010001";
            }
        }

        #endregion Private Methods

        #region IDisposable 

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    if (dbContextTransaction != null)
                    {
                        dbContextTransaction.Dispose();
                    }

                    if (context != null)
                    {
                        context.Dispose();
                    }
                }

                // Free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Set large fields to null.

                disposed = true;
            }
        }

        #endregion IDisposable 
    }
}
