using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Marcelo
{
    public partial class Consultar_Cliente : Form
    {
        public Consultar_Cliente()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dataGridView1.DataSource = null;
                if (textBox1.Text != "")
                {
                    Nutricao nut = new Nutricao();
                    nut.Consultar_Cliente_nome(dataGridView1, textBox1.Text);
                }
            }
            else
            {
                dataGridView1.DataSource = null;
                if (textBox1.Text != "")
                {
                    Nutricao nut = new Nutricao();
                    nut.Consultar_Cliente_cpf(dataGridView1, textBox1.Text);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
         {
             if (radioButton1.Checked == true)
             {
                 dataGridView1.DataSource = null;
                 if (textBox1.Text != "")
                 {
                     Nutricao nut = new Nutricao();
                     nut.Consultar_Cliente_nome(dataGridView1, textBox1.Text);
                 }
             }
             else
             {
                 dataGridView1.DataSource = null;
                 if (textBox1.Text != "")
                 {
                     Nutricao nut = new Nutricao();
                     nut.Consultar_Cliente_cpf(dataGridView1, textBox1.Text);
                 }
             }
         }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal cad = new Principal();
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            { 
                String busca = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                Nutricao nut = new Nutricao();
                if (radioButton1.Checked == true)
                {
                    nut.excluir_cliente(busca, dataGridView1, textBox1.Text);
                    nut.Consultar_Cliente_nome(dataGridView1, textBox1.Text);
                }
                else
                {
                    nut.excluir_cliente(busca, dataGridView1, textBox1.Text);
                    nut.Consultar_Cliente_cpf(dataGridView1, textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário para exclusão !");
            }
        }

        
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int Id_Nutricionista = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string nome = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            string cpf = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            int opcao = 0;
            if (radioButton1.Checked == true)
            {
                opcao = 1;

            }
            else
            {
                opcao = 2;

            }

            Cadastro_Cliente atividade = new Cadastro_Cliente(nome, cpf, Id_Nutricionista, dataGridView1, textBox1.Text, opcao);
            atividade.Show();
        }
    }
}
