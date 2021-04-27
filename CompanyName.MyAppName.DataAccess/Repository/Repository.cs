using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyName.MyAppName.DataAccess.Repositories
{
    /// <summary>
    /// Provides various members to handle database operations of given entity using generic repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="CompanyName.MyAppName.DataAccess.Repositories.IRepository{TEntity}" />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Member Variables

        /// <summary>
        /// The context
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// The database set
        /// </summary>
        protected internal DbSet<TEntity> dbSet;

        #endregion Member Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public Repository(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork.AppDbContext;
            this.dbSet = context.Set<TEntity>();
        }

        #endregion Constructor

        #region Protected Members

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        protected IQueryable<TEntity> Table
        {
            get
            {
                return dbSet;
            }
        }

        /// <summary>
        /// Gets the table with no tracking.
        /// </summary>
        /// <value>
        /// The table with no tracking.
        /// </value>
        protected IQueryable<TEntity> TableWithNoTracking
        {
            get
            {
                return dbSet.AsNoTracking();
            }
        }

        #endregion Protected Members

        #region Public Methods

        /// <summary>
        /// Gets the queryable.
        /// </summary>
        /// <param name="isTrackingRequired">if set to <c>true</c> [is tracking required].</param>
        /// <returns>IQueryable list of entity.</returns>
        public IQueryable<TEntity> GetQueryable(bool isTrackingRequired = true)
        {
            return isTrackingRequired ? Table : TableWithNoTracking;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Entity</returns>
        public TEntity GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbSet.Add(entity);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException">entities</exception>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            dbSet.AddRange(entities);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbSet.Update(entity);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException">entities</exception>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            dbSet.UpdateRange(entities);
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbSet.Remove(entity);
        }

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException">entities</exception>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Executes the raw SQL command.
        /// </summary>
        /// <param name="sqlCommand">The SQL command.</param>
        /// <param name="sqlParameters">The SQL parameters.</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecuteRawSqlCommand(string sqlCommand, Dictionary<string, object> sqlParameters = null)
        {
            int result = 0;

            if (!string.IsNullOrWhiteSpace(sqlCommand))
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                if (sqlParameters != null && sqlParameters.Count > 0)
                {
                    foreach (KeyValuePair<string, object> keyValuePair in sqlParameters)
                    {
                        sqlParams.Add(new SqlParameter(keyValuePair.Key, keyValuePair.Value));
                    }
                }

                result = context.Database.ExecuteSqlRaw(sqlCommand, sqlParams.ToArray());
            }

            return result;
        }

        /// <summary>
        /// Gets the generic entities with raw SQL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="sqlParameters">The SQL parameters.</param>
        /// <returns>IEnumerable list of entity.</returns>
        public IEnumerable<TEntity> GetGenericEntitiesWithRawSql<T>(string query, Dictionary<string, object> sqlParameters = null)
        {
            List<TEntity> result = new List<TEntity>();

            if (!string.IsNullOrWhiteSpace(query))
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                if (sqlParameters != null && sqlParameters.Count > 0)
                {
                    foreach (KeyValuePair<string, object> keyValuePair in sqlParameters)
                    {
                        sqlParams.Add(new SqlParameter(keyValuePair.Key, keyValuePair.Value));
                    }
                }

                result = dbSet.FromSqlRaw(query, sqlParams.ToArray()).ToList();
            }

            return result;
        }

        #endregion Public Methods
    }
}
