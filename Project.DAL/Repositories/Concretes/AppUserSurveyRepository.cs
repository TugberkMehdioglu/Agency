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
    public class AppUserSurveyRepository : BaseRepository<AppUserSurvey>, IAppUserSurveyRepository
    {
        public AppUserSurveyRepository(MyContext context) : base(context)
        {
        }


    }
}
