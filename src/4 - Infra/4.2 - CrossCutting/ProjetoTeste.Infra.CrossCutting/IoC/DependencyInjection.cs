using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Application;
using ProjetoTeste.Application.Services;
using ProjetoTeste.Domain.Interfaces.Repository;
using ProjetoTeste.Domain.Interfaces.Services;
using ProjetoTeste.Domain.Services;
using ProjetoTeste.Infra.Data.Context;
using ProjetoTeste.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Contexto
            services.AddScoped<DbContext>();

            // Produto
            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
