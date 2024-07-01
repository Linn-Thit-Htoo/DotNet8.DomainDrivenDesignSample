using DotNet8.DomainDrivenDesignSample.Api.Features.Blog;
using DotNet8.DomainDrivenDesignSample.Domain.Interfaces.Blog;
using DotNet8.DomainDrivenDesignSample.Infrastructure.AppDbContexts;
using DotNet8.DomainDrivenDesignSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.DomainDrivenDesignSample.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextService(builder)
                .AddRepositoryService()
                .AddBusinessLogicService()
                .AddJsonService();

            return services;
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, BlogRepository>();
            return services;
        }

        private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
        {
            services.AddScoped<BL_Blog>();
            return services;
        }

        private static IServiceCollection AddJsonService(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            return services;
        }
    }
}
