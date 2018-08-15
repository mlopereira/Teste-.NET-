using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Marcelo
{
    class Nutricao
    {
        string nome = "";
        string cpf = "";
        string uf = "";
        int Id_Nutricionista;
        Banco_dados banco = new Banco_dados();
        SqlConnection con;

        public void Cadastrar_cliente()
        {

            con = banco.abrir_conexao();
            string inserir = @"insert into cliente(Nome, Cpf, uf) Values('" + nome + "',  '" + cpf + "', '" + uf + "')";
            SqlCommand _cmd = new SqlCommand(inserir, con);
            _cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Dados inseridos com sucesso ! ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

        public void Consultar_Cliente_nome(DataGridView dataGridView1, string busca)
        {
            con = banco.abrir_conexao();
            string selecionar = @"SELECT Id_Nutricionista,Nome,CPF, uf FROM Cliente where nome collate Latin1_General_CI_AI like '%" + busca + "%'";
            SqlDataAdapter a = new SqlDataAdapter(selecionar, con);
            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;
            con.Close();
        }
        public void Consultar_Cliente_cpf(DataGridView dataGridView1, string busca)
        {
            con = banco.abrir_conexao();
            string selecionar = @"SELECT Id_Nutricionista,Nome,CPF, uf FROM Cliente where CPF collate Latin1_General_CI_AI like '%" + busca + "%'";
            SqlDataAdapter a = new SqlDataAdapter(selecionar, con);
            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;
            con.Close();
        }

        public void excluir_cliente(string busca, DataGridView dataGridView1, string campo_busca)
        {
            con = banco.abrir_conexao();
            // comando SQL para inserir - Insert Into
            string deletar = @"DELETE FROM cliente WHERE Id_Nutricionista='" + busca + "';";

            // inicializa o comando e a conexão

            SqlCommand _cmd = new SqlCommand(deletar, con);
            // executa o comando

            DialogResult dialogResult = MessageBox.Show("Deseja mesmo deletar ? ", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                _cmd.ExecuteNonQuery();
                //atualizar_datagrid(dataGridView1, campo_busca);
                MessageBox.Show("Excluido");
                con.Close();
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something
            }
            con.Close();
        }

        public void editar_cliente()
        {
            con = banco.abrir_conexao();
            string inserir = @"update Cliente Set Nome = '" + nome + "', CPF = '" + cpf + "' where Id_Nutricionista = '" + Id_Nutricionista + "';";
            SqlCommand _cmd = new SqlCommand(inserir, con);

            DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar? ",
                "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                _cmd.ExecuteNonQuery();
                //  atualizar_datagrid(dataGridView1, campo_busca);
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            con.Close();


        }
        public void atualizar_datagrid(DataGridView dataGridView1, string busca)
        {
            con = banco.abrir_conexao();
            string selecionar = @"SELECT Id_Nutricionista,Nome,CPF, uf FROM Cliente where nome like '%" + busca + "%'";
            SqlDataAdapter a = new SqlDataAdapter(selecionar, con);
            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;
            con.Close();
        }
        public void set_nome(String nome)
        {
            this.nome = nome;
        }
        public void set_cpf(String cpf)
        {
            this.cpf = cpf;
        }
        public void set_uf(String uf)
        {
            this.uf = uf;
        }
        public void set_Id_Nutricionista(int Id_Nutricionista)
        {
            this.Id_Nutricionista = Id_Nutricionista;
        }
        public string get_nome()
        {
            return nome;
        }
        public string get_cpf()
        {
            return cpf;
        }
        public string get_uf()
        {
            return uf;
        }
        public int get_Id_Nutricionista()
        {
            return Id_Nutricionista;
        }
    }
}
