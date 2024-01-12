using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Group : BaseEntity
    {
        public string Code { get; set; } = null!;
        public byte Score { get; set; }


        //Navigation Properties
        public ICollection<Question>? Questions { get; set; }
    }
}
