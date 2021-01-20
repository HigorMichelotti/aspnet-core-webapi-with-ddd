using ProjetoTeste.Application.ViewModels.Produto;
using ProjetoTeste.Domain.Core.Messages;
using ProjetoTeste.Domain.Entidades;
using ProjetoTeste.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoService _bancoservice;
        private readonly Result _result;

        public ProdutoApplicationService(IProdutoService bancoservice)
        {
            _bancoservice = bancoservice;
            _result = new Result();
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var produtos = await _bancoservice.ObterTodos();

            var bancosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                bancosViewModel.Add(new ProdutoViewModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Valor = produto.Valor,
                    Imagem = produto.Imagem
                });
            }
 
            return bancosViewModel;
        }

        public async Task<Result> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (string.IsNullOrEmpty(produtoViewModel.Imagem))
            {
                _result.Status = false;
                _result.Mensagem = "Adicione uma imagem ao produto";
                return _result;
            }

            var produto = new Produto(produtoViewModel.Nome, produtoViewModel.Valor, produtoViewModel.Imagem);
            return await _bancoservice.Adicionar(produto);
        }

        public async Task<Result> Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto(produtoViewModel.Nome, produtoViewModel.Valor, produtoViewModel.Imagem);

            if (string.IsNullOrEmpty(produtoViewModel.Imagem))
            {
                _result.Status = false;
                _result.Mensagem = "Adicione uma imagem ao produto";
                return _result;
            }

            produto.SetarId(produtoViewModel.Id);

            return await _bancoservice.Atualizar(produto);
        }

        public async Task<Result> Deletar(string id)
        {
            return await _bancoservice.Deletar(id);
        }
    }
}
