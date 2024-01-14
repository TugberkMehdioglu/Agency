using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface ISurveyManager : IManager<Survey>
    {
        public Task<(string?, Survey?)> GetSurveyWithQuestionAndAnswerById(int surveyId);
    }
}
