using ProjetoTeste.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Interfaces.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<Result> Adicionar(TEntity entidade);
        Task<Result> Atualizar(TEntity obj);
        Task<Result> Deletar(string id);
        Task<IEnumerable<TEntity>> ObterTodos();
        void Dispose();
    }
}
