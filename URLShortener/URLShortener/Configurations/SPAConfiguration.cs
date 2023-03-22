namespace URLShortener.Configurations
{
    public static class SPAConfiguration
    {
        public static IServiceCollection AddSPA(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            return services;
        }
    }
}
