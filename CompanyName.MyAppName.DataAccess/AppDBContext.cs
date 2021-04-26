using CompanyName.MyAppName.DataAccess.EntityMapping;
using Microsoft.EntityFrameworkCore;

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
        public AppDBContext()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>  
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserDetailConfiguration());
        }
    }
}
