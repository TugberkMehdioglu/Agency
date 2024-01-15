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
    public class QuestionManager : BaseManager<Question>, IQuestionManager
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionManager(IRepository<Question> repository, IQuestionRepository questionRepository) : base(repository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IQueryable<Question>> GetQuestionsWithGroupAsync() => await _questionRepository.GetQuestionsWithGroupAsync();
    }
}
