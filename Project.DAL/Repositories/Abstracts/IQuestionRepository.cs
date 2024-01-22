using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task<IQueryable<Question>> GetQuestionsWithGroupAsync();
        public Task<IQueryable<Question>> GetQuestionsAndAnswersWithGroupBySurveyIdAsync(int surveyId);
    }
}
