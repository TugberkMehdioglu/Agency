using Microsoft.EntityFrameworkCore;
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
    public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(MyContext context) : base(context)
        {
        }

        public async Task<Survey?> GetSurveyWithQuestionAndAnswerById(int surveyId) => await _context.Surveys.Where(x => x.Id == surveyId && x.Status != DataStatus.Deleted)
            .Include(x => x.Questions)
            .ThenInclude(x => x.Group)
            .Include(x => x.Questions)
            .ThenInclude(x => x.Answers)
            .Include(x => x.Questions)
            .ThenInclude(x => x.ChildQuestions)
            .FirstOrDefaultAsync();
    }
}
