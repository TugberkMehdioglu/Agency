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
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(MyContext context) : base(context)
        {
        }

        public async Task<IQueryable<Question>> GetQuestionsWithGroupAsync() => _context.Questions.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Group);

        public async Task<IQueryable<Question>> GetQuestionsAndAnswersWithGroupBySurveyIdAsync(int surveyId) => _context.Questions.Where(x => x.SurveyId == surveyId && x.Status != DataStatus.Deleted).Include(x => x.Group).Include(x => x.Answers);
    }
}
