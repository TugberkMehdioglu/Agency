using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUserAnswer : BaseEntity
    {
        public int? AppUserId { get; set; }
        public int? AnswerId { get; set; }

        //Navigation Properties
        public AppUser? AppUser { get; set; }
        public Answer? Answer { get; set; }
    }
}
