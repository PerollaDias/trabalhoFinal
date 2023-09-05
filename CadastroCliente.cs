using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho
{
    public partial class CadastroCliente : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void bt_cadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente1 = new Cliente();
            try
            {

                cliente1.Nome = tx_nome.Text;
                cliente1.Cpf = maskedTextBox1.Text;
                cliente1.Nascimento = maskedTextBox3.Text;
                cliente1.Telefone = maskedTextBox2.Text;

                clientes.Add(cliente1);

                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = clientes;

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ocorreu um erro!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tx_nome.Clear();
            maskedTextBox1.Clear();
            maskedTextBox3.Clear();
            maskedTextBox2.Clear();

        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            clientes.RemoveAt(index);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = clientes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
