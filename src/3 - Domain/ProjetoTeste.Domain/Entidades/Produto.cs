using ProjetoTeste.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Domain.Entidades
{
    public class Produto: Entidade
    {
        public Produto(string nome, decimal valor, string imagem)
        {
            Nome = nome;
            Valor = valor;
            Imagem = imagem;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public string Imagem { get; private set; }

        public void SetarAtributos(string id, string nome, decimal valor, string imagem)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Imagem = imagem;
        }

        public void SetarId(string id)
        {
            Id = id;
        }


        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
