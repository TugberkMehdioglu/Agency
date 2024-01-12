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
    }
}
