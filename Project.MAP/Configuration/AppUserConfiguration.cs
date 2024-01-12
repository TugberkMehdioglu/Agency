using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configuration
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Surveys).WithOne(x => x.AppUser).HasForeignKey(x => x.CreatedBy);
            builder.Ignore(x => x.FullName);

            List<AppUser> users = new()
            {
                new()
                {
                    Id="5c8defd5-91f2-4256-9f16-e7fa7546dec4",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    UserName="Creater",
                    NormalizedUserName="CREATER",
                    Email="creater@gmail.com",
                    NormalizedEmail="CREATER@GMAIL.COM",
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    PhoneNumber="5312292928",
                    LockoutEnabled=true,
                    CreatedDate=DateTime.Now,
                    Status=DataStatus.Inserted,
                    EmailConfirmed=true,
                    PhoneNumberConfirmed=true,
                    Name="Kemal",
                    SurName="Akcan"
                },
                new()
                {
                    Id="5c8defd5-91f2-4256-9f16-e7fa7546fec5",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    UserName="Responder",
                    NormalizedUserName="RESPONDER",
                    Email="responder@gmail.com",
                    NormalizedEmail="RESPONDER@GMAIL.COM",
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    PhoneNumber="5446340539",
                    LockoutEnabled=true,
                    CreatedDate=DateTime.Now,
                    Status=DataStatus.Inserted,
                    EmailConfirmed=true,
                    PhoneNumberConfirmed=true,
                    Name="Sefa",
                    SurName="Er"
                },
                new()
                {
                    Id="5c8defd5-91f2-4256-9f16-e7fa7546gec6",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    UserName="Analyzer",
                    NormalizedUserName="ANALYZER",
                    Email="analyzer@gmail.com",
                    NormalizedEmail="ANALYZER@GMAIL.COM",
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    PhoneNumber="5446340539",
                    LockoutEnabled=true,
                    CreatedDate=DateTime.Now,
                    Status=DataStatus.Inserted,
                    EmailConfirmed=true,
                    PhoneNumberConfirmed=true,
                    Name="Bora",
                    SurName="Öz"
                }
            };

            PasswordHasher<AppUser> hasher= new PasswordHasher<AppUser>();
            users[0].PasswordHash = hasher.HashPassword(users[0], "Password12*");
            users[1].PasswordHash = hasher.HashPassword(users[1], "Password12*");
            users[2].PasswordHash = hasher.HashPassword(users[2], "Password12*");

            builder.HasData(users);
        }
    }
}
