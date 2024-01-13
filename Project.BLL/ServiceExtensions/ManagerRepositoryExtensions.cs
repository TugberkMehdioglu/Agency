using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceExtensions
{
    public static class ManagerRepositoryExtensions
    {
        public static IServiceCollection AddManagerRepsoitoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IAnswerManager, AnswerManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IGroupManager, GroupManager>();
            services.AddScoped<IQuestionManager, QuestionManager>();
            services.AddScoped<ISurveyManager, Surveymanager>();
            services.AddScoped<IAppUserAnswerManager, AppUserAnswerManager>();
            services.AddScoped<IAppUserSurveyManager, AppUserSurveyManager>();


            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IAppUserAnswerRepository, AppUserAnswerRepository>();
            services.AddScoped<IAppUserSurveyRepository, AppUserSurveyRepository>();

            return services;
        }
    }
}
