using CompanyName.MyAppName.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyName.MyAppName.DataAccess.EntityMapping
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable("UserDetail","dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Details)
                            .HasMaxLength(200)
                            .IsRequired();
        }
    }
}
