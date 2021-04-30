using CompanyName.MyAppName.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyName.MyAppName.DataAccess.EntityMapping
{
    public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            builder.ToTable("UserSetting", "dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Setting)
                            .HasMaxLength(200);
            
            builder.HasOne(c => c.User)
                   .WithOne(c => c.UserSetting)
                   .HasForeignKey<UserSetting>(c => c.UserId);

            // Global filter
            //builder.HasQueryFilter(c => c.IsActive == true);
        }
    }
}
