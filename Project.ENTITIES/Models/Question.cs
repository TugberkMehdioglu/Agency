using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = null!;
        public bool IsItAnswered { get; set; }

        public int? ParentQuestionId { get; set; }
        public int SurveyId { get; set; }
        public int GroupId { get; set; }


        //Navigation Properties
        public ICollection<Question>? ChilQuestions { get; set; }
        public Question? ParentQuestion { get; set; }
        public Survey Survey { get; set; } = null!;
        public ICollection<Answer>? Answers { get; set; }
        public Group Group { get; set; } = null!;
    }
}
