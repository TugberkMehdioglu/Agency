using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project.MVCUI.Areas.Creater.CreatorViewModel
{
    public class AnswerViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Cevap")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [StringLength(350, MinimumLength = 3, ErrorMessage = "{0}, {2} ile {1} karakter arasında olmalıdır")]
        public string Text { get; set; } = null!;
        public bool SelectedAnswer { get; set; }//For /Responder/Survey/SolveSurvey
        public int QuestionId { get; set; }


        //Navigation Properties
        public QuestionViewModel Question { get; set; } = null!;
    }
}
