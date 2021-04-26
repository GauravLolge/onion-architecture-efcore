using System.Collections.Generic;
using System.Linq;

namespace CompanyName.MyAppName.DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {       
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        int ExecuteRawSqlCommand(string sqlCommand,
                        Dictionary<string, object> sqlParameters = null);

        TEntity GetById(int Id);

        IQueryable<TEntity> GetQueryable(bool isTrackingRequired = true);

        IEnumerable<TEntity> GetGenericEntitiesWithRawSql<T>(string query,
                                                       Dictionary<string, object> sqlParameters = null);       

    }
}
