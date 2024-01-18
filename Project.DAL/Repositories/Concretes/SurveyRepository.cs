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
             .Select(x => new Survey()
             {
                 Id = x.Id,
                 Name = x.Name,
                 CreatedBy = x.CreatedBy,
                 Questions = x.Questions.Select(x => new Question
                 {
                     Id = x.Id,
                     Text = x.Text,
                     IsItAnswered = x.IsItAnswered,
                     ParentQuestionId = x.ParentQuestionId,
                     Group = new Group()
                     {
                         Id = x.Group.Id,
                         Code = x.Group.Code,
                         Score = x.Group.Score
                     },
                     Answers = x.Answers.Select(x => new Answer
                     {
                         Id = x.Id,
                         Text = x.Text,
                         QuestionId = x.QuestionId
                     }).ToList(),
                     ChildQuestions = x.ChildQuestions.Select(x => new Question
                     {
                         Id = x.Id,
                         Text = x.Text,
                         IsItAnswered = x.IsItAnswered,
                         ParentQuestionId = x.ParentQuestionId,
                         Group = new Group()
                         {
                             Id = x.Group.Id,
                             Code = x.Group.Code,
                             Score = x.Group.Score
                         },
                         Answers = x.Answers.Select(x => new Answer
                         {
                             Id = x.Id,
                             Text = x.Text,
                             QuestionId = x.QuestionId
                         }).ToList(),
                     }).ToList()
                 }).ToList()
             }).FirstOrDefaultAsync();
    }
}
