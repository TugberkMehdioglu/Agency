using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IQuestionManager : IManager<Question>
    {
        public Task<IQueryable<Question>> GetQuestionsWithGroupAsync();
        public Task<IQueryable<Question>> GetQuestionsAndAnswersWithGroupBySurveyIdAsync(int surveyId);
    }
}
