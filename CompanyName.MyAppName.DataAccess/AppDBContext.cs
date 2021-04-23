using CompanyName.MyAppName.DataAccess.EntityMapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyName.MyAppName.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class AppDBContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Sets collection of given entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <returns>Collection the given enity</returns>
        //public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        //{
        //    return base.Set<TEntity>();
        //}

        /// <summary>
        /// 
        /// </summary>  
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
