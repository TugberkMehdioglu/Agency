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
    public class AnswerConfiguration : BaseConfiguration<Answer>
    {
        public override void Configure(EntityTypeBuilder<Answer> builder)
        {
            base.Configure(builder);

            List<Answer> list = new()
            {
                new(){Id=1, Text="Çok memnunum", QuestionId=1, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=2, Text="Memnun değilim", QuestionId=1, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=3, Text="Mükemmel", QuestionId=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=4, Text="İyileştirilebilir", QuestionId=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=5, Text="Çok fazla fayda sağladım", QuestionId=3, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=6, Text="Yeterli değil", QuestionId=3, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=7, Text="Evet, tam olarak", QuestionId=4, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=8, Text="Hayır, daha fazla esneklik istiyorum", QuestionId=4, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=9, Text="Memnunum", QuestionId=5, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=10, Text="Daha fazla geribildirim bekliyorum", QuestionId=5, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=11, Text="Hayır, güvenli hissediyorum", QuestionId=6, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=12, Text="Evet, iyileştirmeler yapılmalı", QuestionId=6, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=13, Text="Yönetilebilir", QuestionId=7, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=14, Text="Yüksek", QuestionId=7, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
            };

            builder.HasData(list);
        }
    }
}
