using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebApi.Setup
{
    public static class SwaggerConfig
    {
        public static void AddCustomSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Projeto Teste Web Api - v1",
                        Version = "v1.0",
                        Description = "API REST com o CRUD de produtos",
                    });

                c.CustomSchemaIds(i => (i.DeclaringType != null) ? $"{i.DeclaringType.Name}.{i.Name}" : i.Name);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

        }
    }
}
