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
    public class QuestionConfiguration : BaseConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.ChildQuestions).WithOne(x => x.ParentQuestion).HasForeignKey(x => x.ParentQuestionId);
            builder.HasMany(x => x.Answers).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);

            List<Question> questions = new()
            {
                new(){Id=1, Text="İş yerindeki genel çalışma ortamından ne kadar memnunsunuz?", SurveyId=1, GroupId=3, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=2, Text="Takım arkadaşlarıyla iletişim ve işbirliği konusundaki deneyimleriniz nedir?", SurveyId=1, GroupId=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=3, Text="Şirket tarafından sunulan eğitim ve gelişim fırsatlarından ne kadar faydalandınız?", ParentQuestionId=2, SurveyId=1, GroupId=1, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=4, Text="Çalışma saatleri ve esneklik konusundaki beklentilerinizi karşılayabiliyor musunuz?", ParentQuestionId=2, SurveyId=1, GroupId=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=5, Text="Performans değerlendirmelerinizle ilgili olarak geribildirim almak konusundaki memnuniyetiniz nedir?", SurveyId=1, GroupId=3, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=6, Text="İş güvenliği önlemleri ve çalışma ortamı konusunda endişeleriniz var mı?", ParentQuestionId=5, SurveyId=1, GroupId=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
                new(){Id=7, Text="İş yükü ve stres seviyeleriniz hakkında nasıl hissediyorsunuz?", SurveyId=1, GroupId=2, CreatedDate=DateTime.Now, Status=DataStatus.Inserted},
            };

            builder.HasData(questions);
        }
    }
}
