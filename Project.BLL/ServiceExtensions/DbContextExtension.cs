using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceExtensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>()!;

            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnectionWithWinAuth"));
            });

            return services;
        }
    }
}
