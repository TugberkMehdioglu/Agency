using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configuration
{
    public class SurveyConfiguration : BaseConfiguration<Survey>
    {
        public override void Configure(EntityTypeBuilder<Survey> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Questions).WithOne(x => x.Survey).HasForeignKey(x => x.SurveyId);
        }
    }
}
