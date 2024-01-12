using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        public SignInManager<AppUser> SignInManager { get; }
        public UserManager<AppUser> UserManager { get; }
        new Task<IEnumerable<IdentityError>?> AddAsync(AppUser entity);
        public Task<AppUser> FindByEmailViaIdentity(string email);
        public Task<SignInResult> PasswordSignInAsync(AppUser appUser, string password, bool rememberMe, bool lockoutOnFailure);
    }
}
