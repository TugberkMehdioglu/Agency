using Microsoft.AspNetCore.Identity;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {
        private readonly IAppUserRepository _appUserRepository;
        public AppUserManager(IRepository<AppUser> repository, IAppUserRepository appUserRepository) : base(repository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<(IEnumerable<IdentityError>?, string?)> AddUserByIdentityAsync(AppUser entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted || entity.PasswordHash == null || entity.Email == null || entity.PhoneNumber == null || entity.UserName == null) return (null, "Lütfen zorunlu alanları doldurun");

            IEnumerable<IdentityError>? errors = await _appUserRepository.AddAsync(entity);

            if (errors != null) return (errors, null);
            else return (null, null);
        }

        public async Task<(string?, AppUser?)> FindByEmailViaIdentity(string email)
        {
            AppUser? appUser = await _appUserRepository.FindByEmailViaIdentity(email);

            if (appUser == null) return ("Kullanıcı bulunamadı", null);
            else return (null, appUser);
        }

        public async Task SignOutAsync() => await _appUserRepository.SignOutAsync();

        public async Task<string?> PasswordSignInAsync(AppUser appUser, string password, bool rememberMe, bool lockoutOnFailure)
        {
            SignInResult result = await _appUserRepository.PasswordSignInAsync(appUser, password, rememberMe, lockoutOnFailure);

            if (result.IsLockedOut) return "20 dakika boyunca giriş yapamazsınız";

            else if (!result.Succeeded) return $"Email veya şifre hatalı, başarısız giriş sayısı => {await _appUserRepository.UserManager.GetAccessFailedCountAsync(appUser)}";

            else return null;
        }
    }
}
