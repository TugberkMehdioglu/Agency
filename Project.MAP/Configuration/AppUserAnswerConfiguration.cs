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
    public class AppUserAnswerConfiguration : BaseConfiguration<AppUserAnswer>
    {
        public override void Configure(EntityTypeBuilder<AppUserAnswer> builder)
        {
            base.Configure(builder);

            builder.Ignore(x => x.Id);
            builder.HasKey(x => new
            {
                x.AppUserId,
                x.AnswerId
            });

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserAnswers).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Answer).WithMany(x => x.AppUserAnswers).HasForeignKey(x => x.AnswerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
