using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configuration
{
    public class GroupConfiguration : BaseConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Questions).WithOne(x => x.Group).HasForeignKey(x => x.GroupId);

            List<Group> groups = new()
            {
                new(){Id=1, CreatedDate=DateTime.Now, Status=DataStatus.Inserted, Code="A", Score=10},
                new(){Id=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted, Code="B", Score=6},
                new(){Id=3, CreatedDate=DateTime.Now, Status=DataStatus.Inserted, Code="C", Score=8}
            };

            builder.HasData(groups);
        }
    }
}
