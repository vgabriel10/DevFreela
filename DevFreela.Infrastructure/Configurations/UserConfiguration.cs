﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(us => us.Id);

            builder
                .HasMany(u => u.Skills)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
