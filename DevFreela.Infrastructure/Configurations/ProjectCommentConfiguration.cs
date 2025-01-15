﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
