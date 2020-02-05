using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Mini.DataServices;
using SchwammyStreams.Backend.Mini.Repositories;
using SchwammyStreams.Backend.Mini.Validators;
using SchwammyStreams.Backend.Model;
using SchwammyStreams.Backend.Orchestrators;

namespace SchwammyStreams.Web.AspNet
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
            services.AddControllersWithViews();

            services.AddDbContext<SchwammyStreamsDbContext>(
                options => options.UseSqlServer(Configuration["ConnectionString:SchwammyStreamsConnection"]));

            services.AddScoped<ISchwammyStreamsDbContext>(provider => provider.GetService<SchwammyStreamsDbContext>());

            services.AddTransient<IEpisodeHistoryOrchestrator, EpisodeHistoryOrchestrator>();
            services.AddTransient<IGetHistoryDtoValidator, GetHistoryDtoValidator>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IEpisodeHistoryConverter, EpisodeHistoryConverter>();
            services.AddTransient<IEpisodeDataService, EpisodeDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
