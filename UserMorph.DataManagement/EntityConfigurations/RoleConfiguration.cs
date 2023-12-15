using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMorph.Core.DTOs.PersistenceModels;

namespace UserMorph.DataManagement.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<UsersRole>
    {
        public void Configure(EntityTypeBuilder<UsersRole> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.UserId });

            builder.HasOne(r => r.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(r => r.UserId);
        }
    }
}
