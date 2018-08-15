using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Marcelo
{
    class Banco_dados
    {
        SqlConnection con;
        public SqlConnection abrir_conexao()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\marcelo.ncpereira\Documents\Banco.mdf;Integrated Security=True;Connect Timeout=30";

            con.Open();
            return con;
        }

        public void fechar_conexao(SqlConnection con)
        {
            con.Close();
        }
    }
}
