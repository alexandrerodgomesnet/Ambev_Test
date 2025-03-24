using Ambev.DeveloperEvaluation.Application;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Extensions;

public static class AssembliesExtensions
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

    public static IServiceCollection AddMediatRFromAssemblies(this IServiceCollection services) =>
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });
}