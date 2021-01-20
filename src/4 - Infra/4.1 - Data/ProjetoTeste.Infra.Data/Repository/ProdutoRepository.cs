using ProjetoTeste.Domain.Core.Messages;
using ProjetoTeste.Domain.Entidades;
using ProjetoTeste.Domain.Interfaces.Repository;
using ProjetoTeste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly DbContext _context;
        protected readonly Result _result;

        public ProdutoRepository(DbContext context)
        {
            _context = context;
            _result = new Result();
        }

        public async Task<Result> Adicionar(Produto produto)
        {
            try
            {
                var stringSql = "insert into produtos (Nome, Valor, Imagem) values (@nome, @valor, @imagem)";

                _context.comando = new SqlCommand(stringSql, _context.conexao);

                _context.comando.Parameters.AddWithValue("@nome", produto.Nome);
                _context.comando.Parameters.AddWithValue("@valor", produto.Valor);
                _context.comando.Parameters.AddWithValue("@imagem", produto.Imagem);

                await _context.comando.ExecuteNonQueryAsync();

                _result.Status = true;
                _result.Mensagem = "Produto adicionado com sucesso";
                _result.Data = "Sucesso";
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.Data = ex;
                _result.Mensagem = "Problemas ao adicionar produto";
            }

            return _result;

        }

        public async Task<Result> Atualizar(Produto produto)
        {
            try
            {
                var stringSql = "update produtos set Nome = @nome, Valor = @valor, Imagem = @imagem Where Id = @id";

                _context.comando = new SqlCommand(stringSql, _context.conexao);

                _context.comando.Parameters.AddWithValue("@id", produto.Id);
                _context.comando.Parameters.AddWithValue("@nome", produto.Nome);
                _context.comando.Parameters.AddWithValue("@valor", produto.Valor);
                _context.comando.Parameters.AddWithValue("@imagem", produto.Imagem);

                await _context.comando.ExecuteNonQueryAsync();

                _result.Status = true;
                _result.Mensagem = "Produto atualizado com sucesso";
                _result.Data = "Sucesso";
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.Data = ex;
                _result.Mensagem = "Problemas ao atualizar produto";
            }

            return _result;
        }

        public async Task<Result> Deletar(string id)
        {
            try
            {
                var stringSql = "delete from produtos where Id = @id";

                _context.comando = new SqlCommand(stringSql, _context.conexao);

                _context.comando.Parameters.AddWithValue("@id", id);

                await _context.comando.ExecuteNonQueryAsync();

                _result.Status = true;
                _result.Mensagem = "Produto excluído com sucesso";
                _result.Data = "Sucesso";
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.Data = ex;
                _result.Mensagem = "Problemas ao excluir produto";
            }

            return _result;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            var produtos = new List<Produto>();

            try
            {
                var stringSql = "select * from produtos";

                _context.comando = new SqlCommand(stringSql, _context.conexao);

                var dados = await _context.comando.ExecuteReaderAsync();

                while (dados.Read())
                {
                    var produto = new Produto(dados["Nome"].ToString(), decimal.Parse(dados["Valor"].ToString()), dados["Imagem"].ToString());
                    produto.SetarId(dados["Id"].ToString());

                    produtos.Add(produto);
                }

                _result.Status = true;
                _result.Mensagem = "Produto excluído com sucesso";
                _result.Data = "Sucesso";
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.Data = ex;
                _result.Mensagem = "Problemas ao excluir produto";
            }

            return produtos;
        }

        public void Dispose()
        {
            _context.conexao.Close();
        }
    }
}
