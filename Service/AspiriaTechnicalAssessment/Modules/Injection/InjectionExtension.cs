using AspiriaTechnicalAssessment.Core.Toys.Toys.Application;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Domain;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Interface;

namespace AspiriaTechnicalAssessment.Modules.Injection
{
    public static class InjectionExtension
    {
        /// <summary>
        /// Add dependency injections
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<IToyApplication, ToyApplication>();
            services.AddTransient<IToyRepository, ToyRepository>();
            return services;
        }
    }
}
