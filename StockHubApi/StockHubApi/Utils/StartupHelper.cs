using Microsoft.Extensions.DependencyInjection;
using StockHubApi.Data;
using StockHubApi.Services;

namespace StockHubApi.Utils
{
    /// <summary>
    /// Provides helper methods to register services in the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class StartupHelper
    {
        /// <summary>
        /// Extension method to add custom services to a <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The instance of <see cref="IServiceCollection"/> on which the extension method is called.</param>
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<StockService>();
        }

        /// <summary>
        /// Extension method to add custom repositories to a <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The instance of <see cref="IServiceCollection"/> on which the extension method is called.</param>
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddTransient<StockRepository>();
        }
    }
}