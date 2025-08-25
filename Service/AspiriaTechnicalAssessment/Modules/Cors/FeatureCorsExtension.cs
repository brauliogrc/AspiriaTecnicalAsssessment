namespace AspiriaTechnicalAssessment.Modules.Cors
{
    public static class FeatureCorsExtension
    {
        /// <summary>
        /// Confiture CORS policy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFeatureCors(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "AspiriaApiPlicy";
            services.AddCors(opts =>
            {
                opts.AddPolicy(myPolicy, builder =>
                {
                    builder.WithOrigins(configuration["Config:OriginCors"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddMvc();

            return services;
        }
    }
}
