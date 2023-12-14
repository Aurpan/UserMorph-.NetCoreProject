﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMorph.DataManagement.Contexts;

#nullable disable

namespace UserMorph.DataManagement.Migrations
{
    [DbContext(typeof(UserMorphDbContext))]
    partial class UserMorphDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("UserMorph.Core.DTOs.PersistenceModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lead"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Staff"
                        });
                });

            modelBuilder.Entity("UserMorph.Core.DTOs.PersistenceModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte>("Sex")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Company = "DSi",
                            FirstName = "Aurpan",
                            IsActive = true,
                            LastName = "Dash",
                            Sex = (byte)0
                        },
                        new
                        {
                            Id = 2,
                            Company = "CEL",
                            FirstName = "Aurgha",
                            IsActive = true,
                            LastName = "Dash",
                            Sex = (byte)0
                        },
                        new
                        {
                            Id = 3,
                            Company = "XYZ",
                            FirstName = "Jannatul",
                            IsActive = true,
                            LastName = "Ferdaus",
                            Sex = (byte)1
                        });
                });

            modelBuilder.Entity("UserMorph.Core.DTOs.PersistenceModels.UserContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserContact");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Mirpur",
                            City = "Dhaka",
                            Country = "BD",
                            Phone = "01667002233",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Hatirjheel",
                            City = "Dhaka",
                            Country = "BD",
                            Phone = "01767002233",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "Uttara",
                            City = "Dhaka",
                            Country = "BD",
                            Phone = "01557992233",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Address = "Banani",
                            City = "Dhaka",
                            Country = "BD",
                            Phone = "01652937539",
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Address = "Oxyzen",
                            City = "Ctg",
                            Country = "BD",
                            Phone = "01557992233",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("UserMorph.Core.DTOs.PersistenceModels.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserMorph.Core.DTOs.PersistenceModels.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMorph.Core.DTOs.PersistenceModels.UserContact", b =>
                {
                    b.HasOne("UserMorph.Core.DTOs.PersistenceModels.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserMorph.Core.DTOs.PersistenceModels.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
