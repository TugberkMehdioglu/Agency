using AutoMapper;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Creater.CreatorViewModel;

namespace Project.MVCUI.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
        }
    }
}
