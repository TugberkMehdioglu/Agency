﻿using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(MyContext context) : base(context)
        {
        }

        public async Task<IQueryable<Group>> GetGroupsWithQuestions() => _context.Groups.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Questions);
    }
}
