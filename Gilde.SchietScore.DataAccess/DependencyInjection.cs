using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Builders;
using Gilde.SchietScore.Persistence.Builders.Interfaces;
using Gilde.SchietScore.Persistence.Factories;
using Gilde.SchietScore.Persistence.Factories.Interfaces;
using Gilde.SchietScore.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gilde.SchietScore.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISchutterRepository, SchutterRepository>();
            services.AddTransient<ISchutterFactory, SchutterFactory>();
            services.AddTransient<ISchutterBuilder, SchutterBuilder>();

            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<SchietScoreDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentityCore<SchietScoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SchietScoreDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddTransient<ISchietScoreDbContext, SchietScoreDbContext>();

            return services;
        }
    }
}
