using CompanyName.MyAppName.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyName.MyAppName.DataAccess.EntityMapping
{

    /// <summary>
    /// Provides configuration for  user entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CompanyName.MyAppName.Core.Entities.User}" />
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="User" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(c => c.Id);

            builder.HasAlternateKey(c => c.Name);

            builder.Property(c => c.Name)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.Password)
                   .HasMaxLength(20)
                   .IsRequired();
        }
    }
}
