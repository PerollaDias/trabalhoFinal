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
    public partial class CadastroServico : Form
    {
        List<Servico> servico = new List<Servico>();
        public CadastroServico()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Servico servico1 = new Servico();
            try
            {

                servico1.Nome = textBox1.Text;
                servico1.Profissional = textBox2.Text;
                servico1.Descrição = textBox3.Text;
                servico1.Valor = maskedTextBox1.Text;

                servico.Add(servico1);

                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = servico;

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ocorreu um erro!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            servico.RemoveAt(index);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = servico;
        }

        private void button4_Click(object sender, EventArgs e)
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
