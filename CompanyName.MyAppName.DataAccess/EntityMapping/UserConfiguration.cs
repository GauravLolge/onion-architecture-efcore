using CompanyName.MyAppName.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyName.MyAppName.DataAccess.EntityMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}
