using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyName.MyAppName.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        protected internal DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        protected IQueryable<TEntity> Table
        {
            get
            {
                return dbSet;
            }
        }

        protected IQueryable<TEntity> TableWithNoTracking
        {
            get
            {
                return dbSet.AsNoTracking();
            }
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            dbSet.UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            dbSet.RemoveRange(entities);
        }

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

        public TEntity GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<TEntity> GetGenericEntitiesWithRawSql<T>(string query, Dictionary<string, object> sqlParameters = null)
        {
            List<T> result = new List<T>();

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

                result = null;
            }

            return null;
        }

        public IQueryable<TEntity> GetQueryable(bool isTrackingRequired = true)
        {
            return isTrackingRequired ? Table : TableWithNoTracking;
        }       
    }
}
