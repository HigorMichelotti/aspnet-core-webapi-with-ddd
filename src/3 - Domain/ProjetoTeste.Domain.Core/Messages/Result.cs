using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Domain.Core.Messages
{
    public class Result
    {
        public bool Status { get; set; }
        public string Source { get; set; }
        public object Mensagem { get; set; }
        public object Data { get; set; }
    }
}
