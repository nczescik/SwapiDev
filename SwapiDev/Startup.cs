using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwapiDev.DAL;
using SwapiDev.Extensions;

namespace SwapiDev
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
            services
                .AddDependencyInjection()
                .AddSpaStaticFiles()
                .AddDbContext(Configuration)
                .AddCors()
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext applicationDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseCorsExt(Configuration);
            }

            app.UseExceptionHandler("/error")
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpointsExt()
                .UseSpa(env);

            applicationDbContext.Database.EnsureCreated();
        }
    }
}
