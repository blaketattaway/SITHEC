using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SITHEC.Application.Common.Behaviors;
using System.Reflection;

namespace SITHEC.Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
