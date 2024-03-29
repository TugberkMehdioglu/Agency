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
    public class AppUserSurveyRepository : BaseRepository<AppUserSurvey>, IAppUserSurveyRepository
    {
        public AppUserSurveyRepository(MyContext context) : base(context)
        {
        }

        public override async Task AddAsync(AppUserSurvey entity)
        {
            await _context.AppUserSurveys!.AddAsync(entity);
            await SaveChangesAsync();
        }

        public override async Task UpdateAsync(AppUserSurvey entity)
        {
            entity.Status = DataStatus.Updated;
            entity.ModifiedDate = DateTime.Now;
            AppUserSurvey toBeUpdated = (await FindAsync(entity.AppUserId, entity.SurveyId))!;
            _context.Entry(toBeUpdated).CurrentValues.SetValues(entity);
            await SaveChangesAsync();
        }
    }
}
