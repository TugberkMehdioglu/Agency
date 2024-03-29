﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IGroupManager : IManager<Group>
    {
        public Task<IQueryable<Group>> GetGroupsWithQuestions();
    }
}
