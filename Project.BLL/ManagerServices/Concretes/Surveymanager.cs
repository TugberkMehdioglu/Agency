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
    public class Surveymanager : BaseManager<Survey>, ISurveyManager
    {
        private readonly ISurveyRepository _surveyRepository;
        public Surveymanager(IRepository<Survey> repository, ISurveyRepository surveyRepository) : base(repository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<(string?, Survey?)> GetSurveyWithQuestionAndAnswerById(int surveyId)
        {
            Survey? survey = await _surveyRepository.GetSurveyWithQuestionAndAnswerById(surveyId);

            if (survey == null) return ("Anket bulunamadı", null);
            else return (null, survey);
        }
    }
}
