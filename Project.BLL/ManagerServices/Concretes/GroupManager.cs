using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class GroupManager : BaseManager<Group>, IGroupManager
    {
        private readonly IGroupRepository _groupRepository;
        public GroupManager(IRepository<Group> repository, IGroupRepository groupRepository) : base(repository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IQueryable<Group>> GetGroupsWithQuestions() => await _groupRepository.GetGroupsWithQuestions();
    }
}
