using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserSurveyManager : BaseManager<AppUserSurvey>, IAppUserSurveyManager
    {
        private readonly IAppUserSurveyRepository _appUserSurveyRepository;
        public AppUserSurveyManager(IRepository<AppUserSurvey> repository, IAppUserSurveyRepository appUserSurveyRepository) : base(repository)
        {
            _appUserSurveyRepository = appUserSurveyRepository;
        }

        public override async Task<string?> AddAsync(AppUserSurvey entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _appUserSurveyRepository.AddAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }
    }
}
