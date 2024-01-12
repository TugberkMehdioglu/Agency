using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IAppUserManager : IManager<AppUser>
    {
        public Task<(IEnumerable<IdentityError>?, string?)> AddUserByIdentityAsync(AppUser entity);
    }
}
