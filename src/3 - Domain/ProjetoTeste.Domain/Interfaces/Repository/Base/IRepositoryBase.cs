using ProjetoTeste.Domain.Core.DomainObjects;
using ProjetoTeste.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entidade
    {
        Task<IEnumerable<TEntity>> ObterTodos();

        Task<Result> Adicionar(TEntity entidade);
        Task<Result> Atualizar(TEntity entidade);
        Task<Result> Deletar(string id);
    }
}
