using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UserMorph.Core.DTOs.DomainModels;
using UserMorph.Core.Interfaces.Domain;
using UserMorph.Core.Interfaces.Persistence;
using UserMorph.Core.Validators;
using UserMorph.DataManagement.Contexts;
using UserMorph.DataManagement.Repositories;
using UserMorph.Services;

namespace UserMorph.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Configure EntityFramework
            builder.Services.AddDbContext<UserMorphDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=UserMorphDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            });

            builder.Services.AddScoped<DbContext, UserMorphDbContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserJsonRepository, UserJsonRepository>();
            builder.Services.AddScoped<IUserService, UserService>();


            // Validators 
            builder.Services.AddScoped<IValidator<User>, UserValidator>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}