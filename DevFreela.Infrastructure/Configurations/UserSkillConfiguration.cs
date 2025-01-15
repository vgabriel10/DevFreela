using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
               .HasKey(us => us.Id);

            builder
                .HasOne(u => u.Skill)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(s => s.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
