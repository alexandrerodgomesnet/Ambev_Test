using System.Reflection;
using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.WebApi.Common.Behaviors;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Extensions;

public static class StartupExtension
{
    public static IServiceCollection AddFromAssembliesValidators(this IServiceCollection services) =>
        services.AddValidatorsFromAssemblies([
            typeof(Program).Assembly, 
            typeof(ApplicationLayer).Assembly
        ], includeInternalTypes: true);

    public static IServiceCollection AddAutoMapperFromAssemblies(this IServiceCollection services) =>
        services.AddAutoMapper(
            typeof(Program).Assembly, 
            typeof(ApplicationLayer).Assembly
        );

    public static IServiceCollection AddMediatRAndServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        var assemblies = new List<Assembly>
        {
            typeof(ApplicationLayer).Assembly,
            typeof(Program).Assembly
        };
        services.AddValidatorsFromAssemblies(assemblies);

        return services;
    }
        


    public static void AddCommonService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqConfiguration>(a => configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
    }
}