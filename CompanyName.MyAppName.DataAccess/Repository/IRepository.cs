using System.Collections.Generic;
using System.Linq;

namespace CompanyName.MyAppName.DataAccess.Repositories
{
    /// <summary>
    /// Provides access to various members of generic repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the queryable.
        /// </summary>
        /// <param name="isTrackingRequired">if set to <c>true</c> [is tracking required].</param>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable(bool isTrackingRequired = true);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        TEntity GetById(int Id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Executes the raw SQL command.
        /// </summary>
        /// <param name="sqlCommand">The SQL command.</param>
        /// <param name="sqlParameters">The SQL parameters.</param>
        /// <returns></returns>
        int ExecuteRawSqlCommand(string sqlCommand,
                        Dictionary<string, object> sqlParameters = null);

        /// <summary>
        /// Gets the generic entities with raw SQL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="sqlParameters">The SQL parameters.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetGenericEntitiesWithRawSql<T>(string query,
                                                       Dictionary<string, object> sqlParameters = null);       

    }
}
