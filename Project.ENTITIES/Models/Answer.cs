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
        public bool SelectedAnswer { get; set; }

        public int QuestionId { get; set; }


        //Navigation Properties
        public Question Question { get; set; } = null!;
    }
}
