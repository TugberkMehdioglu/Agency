using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Responder.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Project.MVCUI.Areas.Creater.CreatorViewModel
{
    public class SurveyViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Anket Adı")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "{0}, {2} ile {1} karakter arasında olmalıdır")]
        public string Name { get; set; } = null!;


        //AppUser foreignKey for creator of survey
        public int? CreatedBy { get; set; }

        public SaveAnswerViewModel? SaveAnswer { get; set; }//For Responder/Survey/SolveSurvey

        //Navigation Properties
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
