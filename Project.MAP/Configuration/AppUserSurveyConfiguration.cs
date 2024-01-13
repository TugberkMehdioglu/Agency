using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configuration
{
    public class AppUserSurveyConfiguration : BaseConfiguration<AppUserSurvey>
    {
        public override void Configure(EntityTypeBuilder<AppUserSurvey> builder)
        {
            base.Configure(builder);

            builder.Ignore(x => x.Id);
            builder.HasKey(x => new
            {
                x.AppUserId,
                x.SurveyId
            });

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserSurveys).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Survey).WithMany(x => x.AppUserSurveys).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Score).HasPrecision(4, 2);
        }
    }
}
