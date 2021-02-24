using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StockHubApi
{
    /// <summary>
    /// Provides functionalities to provide correct configuration of the program for startup.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry function which is called at application start.
        /// Calls a CreateHostBuilder method to create and configure a builder object.
        /// </summary>
        /// <param name="args">Arguments which can be passed via cli for additional application configuration.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a new <see cref="IHostBuilder"/> to configure the application for startup depending on the its arguments.
        /// </summary>
        /// <param name="args">Arguments which can be passed via cli for additional configuration of the <see cref="IHostBuilder"/>.</param>
        /// <returns>A new and configured instance of <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
#if DEBUG
                    logging.AddDebug();
#endif
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}