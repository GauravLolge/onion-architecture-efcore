using CompanyName.MyAppName.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.MyAppName.DataAccess.EntityMapping
{
    /// <summary>
    /// Provides configuration for base entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CompanyName.MyAppName.Core.Entities.BaseEntity}" />
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
           builder.Property(c => c.RowVersion)
                .IsRequired()
                .HasComputedColumnSql()
                .IsRowVersion()
                .IsConcurrencyToken()
                ;
        }
    }
}
