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
    public partial class CadastroProduto : Form
    {
        List<Produto> produto = new List<Produto>();
        public CadastroProduto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produto produto1 = new Produto();

            try
            {
                produto1.Código = maskedTextBox2.Text;
                produto1.Descrição = textBox5.Text;
                produto1.Valor = maskedTextBox3.Text;
                produto1.Nome = textBox1.Text;
                produto1.Quantidade = maskedTextBox1.Text;


                produto.Add(produto1);


                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = produto;
            }


            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            maskedTextBox2.Clear();
            textBox5.Clear();
            maskedTextBox3.Clear();
            textBox1.Clear();
            maskedTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            produto.RemoveAt(index);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = produto;
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
