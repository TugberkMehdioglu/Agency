using Project.ENTITIES.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.MVCUI.Areas.Creater.CreatorViewModel
{
    public class QuestionViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Anket Sorusu")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [StringLength(350, MinimumLength = 3, ErrorMessage = "{0}, {2} ile {1} karakter arasında olmalıdır")]
        public string Text { get; set; } = null!;
        public bool IsItAnswered { get; set; }//For score property on Survey entity.

        public int? ParentQuestionId { get; set; }
        public int SurveyId { get; set; }

        [Display(Name = "Grup")]
        [Required(ErrorMessage = "{0} zorunludur")]
        public int GroupId { get; set; }


        //Navigation Properties
        public List<QuestionViewModel>? ChildQuestions { get; set; }
        public QuestionViewModel? ParentQuestion { get; set; }
        public List<AnswerViewModel> Answers { get; set; } = null!;
    }
}
