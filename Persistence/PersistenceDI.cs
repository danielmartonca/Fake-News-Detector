using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.v1;

namespace Persistence
{
    public static class PersistenceDI
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<NewsContext>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("MyConnection"),
            //         b => b.MigrationsAssembly(typeof(NewsContext).Assembly.FullName)));
            // services.AddScoped<IApplicationContext>(provider => provider.GetService<NewsContext>());

            services.AddDbContext<NewsContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
            });
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
