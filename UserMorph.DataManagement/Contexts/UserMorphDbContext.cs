using Microsoft.EntityFrameworkCore;
using UserMorph.Core.DTOs.PersistenceModels;
using UserMorph.DataManagement.EntityConfigurations;

namespace UserMorph.DataManagement.Contexts
{
    public class UserMorphDbContext : DbContext
    {
        public UserMorphDbContext(DbContextOptions<UserMorphDbContext> options): base(options) 
        {

        }


        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserContact> UserContact { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();

        }

        
    }
}
