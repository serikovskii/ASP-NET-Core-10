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
            //services.AddTransient<IEntitySaverService, EntitySaverService>(); // ������ ��� ����� ������
            //services.AddSingleton<IEntitySaverService, EntitySaverService>(); // ���� ��� ������ ��������� ��� ����
            services.AddScoped<IEntitySaverService, EntitySaverService>(); // ����� ������ ��������� ��� ������� �������
            services.AddScoped<IEmailSenderServices, EmailSenderService>(); // ����� ������ ��������� ��� ������� �������
            services.AddScoped<ISmsSenderServices, SmsSenderServive>(); // ����� ������ ��������� ��� ������� �������
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
