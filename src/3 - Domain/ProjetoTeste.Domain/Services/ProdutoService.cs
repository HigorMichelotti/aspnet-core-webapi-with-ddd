using ProjetoTeste.Domain.Entidades;
using ProjetoTeste.Domain.Interfaces.Repository;
using ProjetoTeste.Domain.Interfaces.Services;
using ProjetoTeste.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
    }
}
