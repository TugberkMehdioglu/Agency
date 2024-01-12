using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Survey : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal? Score { get; set; }

        public string? RespondingUser { get; set; }
        public string CreatedBy { get; set; } = null!;


        //Navigation Properties
        public AppUser AppUser { get; set; } = null!;
        public ICollection<Question>? Questions { get; set; }
    }
}
