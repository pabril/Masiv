using CORE.Api.Repositories;
using CORE.Api.Services;
using CORE.Commons.Tools;
using EasyCaching.Core.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CORE.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOptions();
            services.Configure<GlobalSettings>(Configuration.GetSection(nameof(GlobalSettings)));
            

            var globalSettings = new GlobalSettings();
            Configuration.GetSection(nameof(GlobalSettings)).Bind(globalSettings);
            services.AddSingleton(globalSettings);

            services.AddEasyCaching(options =>
            {
                options.UseRedis(redisConfig =>
                {
                    redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint(globalSettings.ConnectionString, globalSettings.PortNumber));
                    redisConfig.DBConfig.AllowAdmin = true;
                },
                globalSettings.DataBaseName);
            });

            services.AddScoped(typeof(ICacheService<>), typeof(CacheService<>));
            services.AddScoped<IRouletteRepository, RouletteRepository>();
            services.AddScoped<IBetRepository, BetRepository>();
            //services.AddScoped<IRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
