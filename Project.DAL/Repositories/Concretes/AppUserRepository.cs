using Microsoft.AspNetCore.Identity;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AppUserRepository(MyContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public SignInManager<AppUser> SignInManager { get { return _signInManager; } }
        public UserManager<AppUser> UserManager { get { return _userManager; } }

        public override async Task<IEnumerable<IdentityError>?> AddAsync(AppUser entity)
        {
            IdentityResult result = await _userManager.CreateAsync(entity, entity.PasswordHash);
            if (result.Succeeded!) return result.Errors;

            await _signInManager.SignInAsync(entity, true);
            return null;
        }

        public async Task<AppUser> FindByEmailViaIdentity(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task<SignInResult> PasswordSignInAsync(AppUser appUser, string password, bool rememberMe, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(appUser, password, rememberMe, lockoutOnFailure);
        }
    }
}
