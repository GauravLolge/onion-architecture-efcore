using CompanyName.MyAppName.DataAccess.EntityMapping;
using CompanyName.MyAppName.Infra;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyName.MyAppName.DataAccess
{
    /// <summary>
    /// Provides in-memory representation of database as a database context.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        public AppDbContext()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            AddShadowProperties(modelBuilder);
        }

        /// <summary>
        /// Adds the shodow properties.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private void AddShadowProperties(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();

            foreach (var entity in allEntities)
            {
                entity.AddProperty(Constants.ShadowProperty.CreatedBy, typeof(string));
                entity.AddProperty(Constants.ShadowProperty.CreatedDate, typeof(DateTime));
                entity.AddProperty(Constants.ShadowProperty.ModifiedBy, typeof(string));
                entity.AddProperty(Constants.ShadowProperty.ModifiedDate, typeof(DateTime));
            }
        }
    }
}
