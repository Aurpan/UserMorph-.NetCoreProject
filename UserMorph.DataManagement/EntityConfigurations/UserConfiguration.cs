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

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(200).IsUnicode(true);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(200).IsUnicode(true);
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.Company).HasMaxLength(200).IsUnicode(true);
            builder.Property(u => u.Sex).IsRequired();

            builder.HasMany(u => u.Contacts)
                .WithOne(uc => uc.User);

            builder.HasMany(u => u.Roles);
        }
    }
}
