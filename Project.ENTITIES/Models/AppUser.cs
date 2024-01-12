using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUser : IdentityUser, IEntity
    {
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string FullName { get { return $"{Name} {SurName}"; } }//Will not be in database
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }


        //Navigation Properties
        public ICollection<Survey>? Surveys { get; set; }
    }
}
