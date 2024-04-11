namespace CalcService.Api
{
    public static class ResultFormatterRegistry
    {
        public static IServiceCollection AddResultFormatters(this IServiceCollection services)
        {
            services.AddSingleton<IResultFormatter<decimal>, ResultFormatter<decimal>>();
            return services;
        }
    }
}
