using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Electronic_department.Application.Common.Behaviors;

namespace Electronic_department.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
