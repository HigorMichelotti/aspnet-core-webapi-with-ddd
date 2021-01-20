using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoTeste.Infra.CrossCutting.IoC;
using ProjetoTeste.WebApi.Setup;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyInjection.RegisterServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCustomSwaggerConfig();
            services.AddCors(options => options.AddPolicy("ProjetoTestePolicy",
            builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.WithOrigins("http://localhost:4200");
                builder.AllowCredentials();
            }));

            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOptions();

            services.AddRouting(options => options.LowercaseUrls = true);
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[] { new CultureInfo("pt-BR") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Teste WebApi - V1");
                c.DocExpansion(DocExpansion.None);
                c.EnableFilter();
            });

            app.UseRouting();
            app.UseCors("ProjetoTestePolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHub<NotificationsHub>("/notificationsHub");
            });
        }
    }
}
