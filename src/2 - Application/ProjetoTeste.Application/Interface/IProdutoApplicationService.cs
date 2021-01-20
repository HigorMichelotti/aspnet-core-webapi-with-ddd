using ProjetoTeste.Application.ViewModels.Produto;
using ProjetoTeste.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Application
{
    public interface IProdutoApplicationService
    {
        Task<Result> Adicionar(ProdutoViewModel produto);
        Task<Result> Atualizar(ProdutoViewModel produto);
        Task<Result> Deletar(string Id);

        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
    }
}
