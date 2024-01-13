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


        //AppUser foreignKey for creator of survey
        public int CreatedBy { get; set; }


        //Navigation Properties
        public AppUser AppUser { get; set; } = null!;//AppUser foreignKey for creator of survey
        public ICollection<AppUserSurvey>? AppUserSurveys { get; set; }//For responders
        public ICollection<Question>? Questions { get; set; }
    }
}
