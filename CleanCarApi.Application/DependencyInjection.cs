using CleanCarApi.Application.Behaviors;
using CleanCarApi.Application.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanCarApi.Application;

// Extension-metod som registrerar allt Application-lagret behöver
// Anropas från Program.cs med: builder.Services.AddApplication()
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

        return services;
    }
}
