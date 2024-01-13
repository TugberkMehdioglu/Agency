using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; } = null!;

        public int QuestionId { get; set; }


        //Navigation Properties
        public Question Question { get; set; } = null!;
        public ICollection<AppUserAnswer>? AppUserAnswers { get; set; }
    }
}
