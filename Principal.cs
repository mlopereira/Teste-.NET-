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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void cadastrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_Cliente cad = new Cadastro_Cliente();
            cad.Show();
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar_Cliente cad = new Consultar_Cliente();
            cad.Show();
        }

    }
}
