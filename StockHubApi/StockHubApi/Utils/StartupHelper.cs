using Microsoft.Extensions.DependencyInjection;
using StockHubApi.Data;
using StockHubApi.Services;

namespace StockHubApi.Utils
{
    public static class StartupHelper
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<StockService>();
        }

        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddTransient<StockRepository>();
        }
    }
}
