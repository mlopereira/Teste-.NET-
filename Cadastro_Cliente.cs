using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Marcelo
{
    public partial class Cadastro_Cliente : Form
    {
        int flag = 0;
        int Id_Nutricionista;
        int opcao = 0;
        DataGridView datagrid;
        String busca;

        public Cadastro_Cliente()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public Cadastro_Cliente(string nome, string cpf, int Id_Nutricionista, DataGridView data, string texto, int opcao)
        {
           InitializeComponent();
            textBox3.Text = nome;
            textBox4.Text = cpf;
            datagrid = data;
            busca = texto;
            this.opcao = opcao;
            comboBox1.SelectedIndex = 0;
            this.Id_Nutricionista = Id_Nutricionista;
            flag = 1;
            button2.Text = "Editar";
        }

        
           

            private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Principal cad = new Principal();
                this.Close();
                
            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void button2_Click_1(object sender, EventArgs e)
            {
                string nome = textBox3.Text;
                string cpf = textBox4.Text;
                string uf = comboBox1.Text;

                Nutricao cliente = new Nutricao();
                cliente.set_cpf(cpf);
                cliente.set_nome(nome);
                cliente.set_uf(uf);
                cliente.set_Id_Nutricionista(Id_Nutricionista);

                if (flag == 0)
                {
                    cliente.Cadastrar_cliente();
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    string nome_combo = comboBox1.Text;
                }
                else
                {
                    cliente.editar_cliente();
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    string nome_combo = comboBox1.Text;
                    this.Close();

                    if (opcao == 1)
                    {
                        cliente.Consultar_Cliente_nome(datagrid, busca);
                    }
                    else
                    {
                        cliente.Consultar_Cliente_cpf(datagrid, busca);
                    }
                }

               
            }
        }

             
    }
