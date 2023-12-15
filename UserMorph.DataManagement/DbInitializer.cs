using Microsoft.EntityFrameworkCore;
using UserMorph.Core.DTOs.PersistenceModels;
using UserMorph.Core.Enums;

namespace UserMorph.DataManagement
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            // User Data
            _modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Aurpan",
                        LastName = "Dash",
                        Company = "DSi",
                        IsActive = true,
                        Sex = Core.Enums.Gender.Male
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Aurgha",
                        LastName = "Dash",
                        Company = "CEL",
                        IsActive = true,
                        Sex = Core.Enums.Gender.Male
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Jannatul",
                        LastName = "Ferdaus",
                        Company = "XYZ",
                        IsActive = true,
                        Sex = Core.Enums.Gender.Female
                    }
                );


            // UserContact Data
            _modelBuilder.Entity<UserContact>()
                .HasData(
                    new UserContact
                    {
                        Id = 1,
                        UserId = 1,
                        Phone = "01667002233",
                        Address = "Mirpur",
                        City = "Dhaka",
                        Country = "BD"
                    },
                    new UserContact
                    {
                        Id = 2,
                        UserId = 1,
                        Phone = "01767002233",
                        Address = "Hatirjheel",
                        City = "Dhaka",
                        Country = "BD"
                    },
                    new UserContact
                    {
                        Id = 3,
                        UserId = 2,
                        Phone = "01557992233",
                        Address = "Uttara",
                        City = "Dhaka",
                        Country = "BD"
                    },
                    new UserContact
                    {
                        Id = 4,
                        UserId = 2,
                        Phone = "01652937539",
                        Address = "Banani",
                        City = "Dhaka",
                        Country = "BD"
                    },
                    new UserContact
                    {
                        Id = 5,
                        UserId = 3,
                        Phone = "01557992233",
                        Address = "Oxyzen",
                        City = "Ctg",
                        Country = "BD"
                    }
                );



            // Role Data
            _modelBuilder.Entity<UsersRole>()
                .HasData(
                    new UsersRole { UserId = 1, RoleId = UserRole.Manager },
                    new UsersRole { UserId = 1, RoleId = UserRole.Admin },
                    new UsersRole { UserId = 2, RoleId = UserRole.Manager },
                    new UsersRole { UserId = 2, RoleId = UserRole.Lead },
                    new UsersRole { UserId = 3, RoleId = UserRole.Staff }
                );
        }
    }
}
