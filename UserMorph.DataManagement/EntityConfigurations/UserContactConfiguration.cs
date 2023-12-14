using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMorph.Core.DTOs.PersistenceModels;

namespace UserMorph.DataManagement.EntityConfigurations
{
    public class UserContactConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.Property(uc => uc.Phone).HasMaxLength(20);
            builder.Property(uc => uc.Address).HasMaxLength(200);
            builder.Property(uc => uc.City).HasMaxLength(200);
            builder.Property(uc => uc.Country).HasMaxLength(200);

            builder.HasKey(uc => uc.Id);

            builder.HasOne(uc => uc.User)
                .WithMany(u => u.Contacts)
                .HasForeignKey(uc => uc.UserId);
        }
    }
}
