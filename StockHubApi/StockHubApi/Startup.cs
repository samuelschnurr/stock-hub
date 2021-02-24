using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockHubApi.Data;
using StockHubApi.Utils;

namespace StockHubApi
{
    /// <summary>
    /// Configures services for the application at startup and handles the request pipeline.
    /// </summary>
    public class Startup
    {
        private const string AllowSpecificOrigins = "AllowSpecificOrigins";

        /// <summary>
        /// The default constructor to initialize a new instance of <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">A via dependency injection loaded instance of <see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Provides access to global configuration files like appsettings.json to configure the application.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime.
        /// Can be used add services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> in which services will be registered.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(Configuration[AllowSpecificOrigins]);
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddControllers(config => { config.Filters.Add(typeof(ExceptionFilter)); });
            services.AddCustomServices();
            services.AddCustomRepositories();
            services.AddDbContext<StockHubDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("StockHubDb")));
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Can be used to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The via dependency injection loaded instance of <see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The via dependency injection loaded instance of <see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}