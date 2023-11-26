using Microsoft.AspNetCore.Mvc.Infrastructure;
using QualiWatchApi.Api.Common.Erros;

namespace QualiWatchApi.Api
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, QApiProblemDetailsFactory>();
            return services;
        }
    }
}
