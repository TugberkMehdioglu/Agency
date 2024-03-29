﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        public Task<Survey?> GetSurveyWithQuestionAndAnswerById(int surveyId);
    }
}
