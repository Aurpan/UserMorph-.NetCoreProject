using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMorph.Core.DTOs.PersistenceModels;

namespace UserMorph.DataManagement.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).HasMaxLength(200);
            builder.Property(u => u.LastName).HasMaxLength(200);
            builder.Property(u => u.IsActive);
            builder.Property(u => u.Company).IsRequired(false).HasMaxLength(200);
            builder.Property(u => u.Sex);

            builder.HasMany(u => u.Contacts)
                .WithOne(uc => uc.User);

            builder.HasMany(u => u.Roles);
        }
    }
}
