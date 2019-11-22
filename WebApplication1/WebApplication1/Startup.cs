using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddTransient<IEntitySaverService, EntitySaverService>(); // каждый раз новый объект
            //services.AddSingleton<IEntitySaverService, EntitySaverService>(); // один раз объект создается для всех
            services.AddScoped<IEntitySaverService, EntitySaverService>(); // новый объект создается для каждого запроса
            services.AddScoped<IEmailSenderServices, EmailSenderService>(); // новый объект создается для каждого запроса
            services.AddScoped<ISmsSenderServices, SmsSenderServive>(); // новый объект создается для каждого запроса
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(options => options.MapRoute("default", "api/{controller}"));
        }
    }
}
