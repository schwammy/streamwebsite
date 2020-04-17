using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Mini.DataServices;
using SchwammyStreams.Backend.Mini.Repositories;
using SchwammyStreams.Backend.Mini.Validators;
using SchwammyStreams.Backend.Model;
using SchwammyStreams.Backend.Orchestrators;

namespace SchwammyStreams.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.AddApplicationInsightsTelemetry();

            services.AddControllers();

            services.AddDbContext<SchwammyStreamsDbContext>(
    options => options.UseSqlServer(Configuration["ConnectionString:SchwammyStreamsConnection"]));

            services.AddScoped<ISchwammyStreamsDbContext>(provider => provider.GetService<SchwammyStreamsDbContext>());


            services.AddTransient<IEpisodeHistoryOrchestrator, EpisodeHistoryOrchestrator>();
            services.AddTransient<IGetHistoryDtoValidator, GetHistoryDtoValidator>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IEpisodeHistoryConverter, EpisodeHistoryConverter>();
            services.AddTransient<IEpisodeDataService, EpisodeDataService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAddEpisodeDtoValidator, AddEpisodeDtoValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
