using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoTeste.Infra.Data.Context
{
    public class DbContext
    {
        protected string server = @"NB-HIGOR-HD\SQLEXPRESS";
        protected string dataBase = "ProjetoTeste";

        public SqlConnection conexao;
        public SqlCommand comando;
        public SqlDataAdapter dataAdapter;
        public SqlDataReader dataReader;

        public DbContext()
        {
            conexao = new SqlConnection(@"Server=NB-HIGOR-HD\SQLEXPRESS;Database=ProjetoTeste; Integrated Security=True;");
            conexao.Open();
        }
    }
}
