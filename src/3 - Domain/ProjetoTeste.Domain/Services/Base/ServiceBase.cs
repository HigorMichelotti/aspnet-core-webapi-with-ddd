using ProjetoTeste.Domain.Core.DomainObjects;
using ProjetoTeste.Domain.Core.Messages;
using ProjetoTeste.Domain.Interfaces.Base;
using ProjetoTeste.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Services.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entidade
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        public async Task<Result> Adicionar(TEntity entidade)
        {
            return await _repository.Adicionar(entidade);
        }

        public async Task<Result> Atualizar(TEntity obj)
        {
            return await _repository.Atualizar(obj);
        }

        public async Task<Result> Deletar(string id)
        {
            return await _repository.Deletar(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
