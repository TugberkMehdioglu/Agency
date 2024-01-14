using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.ContextClasses
{
    public class MyContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//For IdentityUserRole's primary key issue

            builder.ApplyConfigurationsFromAssembly(Assembly.Load("Project.MAP"));

            //DataSeed for identity tables
            SeedRoles(builder);
            SeedUserRoles(builder);
        }

        public DbSet<Answer>? Answers { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Survey>? Surveys { get; set; }
        public DbSet<AppUserAnswer>? AppUserAnswers { get; set; }
        public DbSet<AppUserSurvey>? AppUserSurveys { get; set; }



        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>()
            {
                Id = 1,
                Name = "Creator",
                NormalizedName = "CREATOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole<int>()
            {
                Id = 2,
                Name = "Responder",
                NormalizedName = "RESPONDER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole<int>()
            {
                Id = 3,
                Name = "Analyzer",
                NormalizedName = "ANALYZER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }


        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>()
            {
                UserId = 1,
                RoleId = 1
            },
            new IdentityUserRole<int>()
            {
                UserId = 2,
                RoleId = 2
            },
            new IdentityUserRole<int>()
            {
                UserId = 3,
                RoleId = 3
            });
        }
    }
}
