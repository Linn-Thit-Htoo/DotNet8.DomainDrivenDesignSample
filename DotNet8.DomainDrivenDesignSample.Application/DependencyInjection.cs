using Microsoft.Extensions.DependencyInjection;

namespace DotNet8.DomainDrivenDesignSample.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cf =>
            cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );
        return services;
    }
}
