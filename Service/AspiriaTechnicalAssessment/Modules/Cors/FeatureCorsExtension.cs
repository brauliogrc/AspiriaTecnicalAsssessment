namespace AspiriaTechnicalAssessment.Modules.Cors
{
    public static class FeatureCorsExtension
    {
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
