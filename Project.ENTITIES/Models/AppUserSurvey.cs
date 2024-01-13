using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUserSurvey : BaseEntity
    {
        public int? AppUserId { get; set; }
        public int? SurveyId { get; set; }
        public decimal? Score { get; set; }


        //Navigation Properties
        public AppUser? AppUser { get; set; }
        public Survey? Survey { get; set; }
    }
}
